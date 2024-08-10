using POSAppModels;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;

namespace POSAppCore
{
	public class NewOrderPageViewModel : BasePageViewModel
	{
		#region PRIVATE MEMEBERS

		private bool _isLoading;
		private MenuDto _menuData = null;
		private OrderDetailsDataModel _currentDetailsView = OrderDetailsDataModel.OrderBill;
        private bool _isNavigate = false;

        #endregion

        #region PUBLIC PROPERTIES
        public bool IsLoading
		{
			get => _isLoading;
			set => SetProperty(ref _isLoading, nameof(IsLoading), value);
		}
        public OrderDetailsDataModel CurrentDetailsView
        {
            get => _currentDetailsView;
            set => SetProperty(ref _currentDetailsView, nameof(CurrentDetailsView), value);
        }        
		public bool IsNavigate
        {
			get => _isNavigate;
			set => SetProperty(ref _isNavigate, nameof(IsNavigate), value);
		}

        public bool HasNoMenus { get => Menus is null || Menus.Count == 0; }
		public bool HasNoCategories { get => Categories is null || Categories.Count == 0; }
		public bool HasNoItems { get => Items is null || Items.Count == 0; }

		public ObservableCollection<OrderMenuViewModel> Menus { get; set; }
		public ObservableCollection<OrderCategoryViewModel> Categories { get; set; }
		public ObservableCollection<OrderItemViewModel> Items { get; set; }

        public OrderBillViewModel OrderBillViewModel { get; set; }
		public OrderBillInfoViewModel OrderBillInfoViewModel { get; set; }
        public ItemCustomizationViewModel ItemCustomizationViewModel { get; set; }

        #endregion

        #region ICONS		
        public Icons BackIcon { get; set; } = Icons.BackIcon;
        #endregion

        #region COMMANDS

        public ICommand BackToOrderBillCommand { get; set; }
        public ICommand PlaceOrderCommand { get; set; }

        #endregion

        #region CONSTRUCTOR

        public NewOrderPageViewModel()
		{
			OrderBillViewModel = new OrderBillViewModel();
			OrderBillInfoViewModel = new OrderBillInfoViewModel();
			ItemCustomizationViewModel = new ItemCustomizationViewModel();

			Menus = new ObservableCollection<OrderMenuViewModel>();
			Menus.CollectionChanged += OnMenuCollectionChanged;

			Categories = new ObservableCollection<OrderCategoryViewModel>();
			Categories.CollectionChanged += OnCategoriesCollectionChanged;

			Items = new ObservableCollection<OrderItemViewModel>();
			Items.CollectionChanged += OnItemsCollectionChanged;

            BackToOrderBillCommand = new RelayCommand(BackToOrderBill);
            PlaceOrderCommand = new RelayCommand(PlaceOrder);

            OnInitAsync();
		}

		#endregion

		#region PRIVATE METHODS

		private async Task OnInitAsync()
		{
			await RunCommand(() => this.IsLoading, async () =>
			{
				_menuData = await IoC.MenuServices.GetMenusAsync();
			});

			//Load the menus..
			if(_menuData != null)
			{
				foreach (var item in _menuData.buttons_cat)
					Menus.Add(new OrderMenuViewModel() { Id = item.id, MenuName = item.name });

				OnPropertyChanged(nameof(HasNoMenus));
			}
		}

        private void BackToOrderBill(object args)
		{
            IsNavigate = false;
            CurrentDetailsView = OrderDetailsDataModel.OrderBill;
        }
        private void PlaceOrder(object args)
		{
            CurrentDetailsView = OrderDetailsDataModel.OrderInfo;
			IsNavigate = true;
        }

        private void OnMenuCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
		{
			if(e.Action == NotifyCollectionChangedAction.Add)
			{
				foreach(OrderMenuViewModel item in e.NewItems)
				{
					item.OnLoadingCategories += () =>
					{
						Categories.Clear();

						foreach (var category in _menuData.buttons_cat.FirstOrDefault(i => i.id == item.Id).level2.Take(10))
						{
							Categories.Add(new OrderCategoryViewModel() { Id = category.id, CategoryName = category.name });
						}

						OnPropertyChanged(nameof(HasNoCategories));
					};
				}
			}
			else if (e.Action == NotifyCollectionChangedAction.Remove)
			{
				foreach (var item in e.OldItems)
				{

				}
			}
		}
		private void OnCategoriesCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				foreach (OrderCategoryViewModel item in e.NewItems)
				{
					item.OnLoadingItems += () =>
					{
						Items.Clear();

						var items = _menuData.buttons_cat.SelectMany(i => i.level2)
											 .FirstOrDefault(i => i.id == item.Id)
											 ?.items;
						
						foreach (var product in items)
						{
							Items.Add(new OrderItemViewModel()
							{
								Id = product.id,	
								ItemName = product.name,
								Price = product.price,
								HasCustomItems = product.items.Any() || product.isbasic.Any() || product.addItems.Any() || product.deleteItems.Any(),
							});
						}

						OnPropertyChanged(nameof(HasNoItems));
					};
				}
			}
			else if (e.Action == NotifyCollectionChangedAction.Remove)
			{
				foreach (var item in e.OldItems)
				{

				}
			}
		}
		private void OnItemsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				foreach (OrderItemViewModel item in e.NewItems)
				{
					item.OnAddingNewItem += (addedItem) =>
					{
						if (addedItem.HasCustomItems)
						{
							var products = _menuData.buttons_cat.SelectMany(m => m.level2).SelectMany(m => m.items);
							var selectedProduct = products.FirstOrDefault(p => p.id == addedItem.Id);

							if(selectedProduct.isbasic.Any())
							{
								((OrderItemViewModel)addedItem).BasicItems = new List<OrderItemViewModel>();
								BuildGroupedItems(selectedProduct.isbasic, ((OrderItemViewModel)addedItem), GroupTypes.Basic);
                            }
                            if (selectedProduct.addItems.Any())
                            {
                                ((OrderItemViewModel)addedItem).ExtraItems = new List<OrderItemViewModel>();
                                BuildGroupedItems(selectedProduct.addItems, ((OrderItemViewModel)addedItem), GroupTypes.Extra);
                            }
                            if (selectedProduct.deleteItems.Any())
                            {
                                ((OrderItemViewModel)addedItem).RemovedItems = new List<OrderItemViewModel>();
                                BuildGroupedItems(selectedProduct.deleteItems, ((OrderItemViewModel)addedItem), GroupTypes.Removed);
                            }
                            if (selectedProduct.items.Any())
                            {
                                ((OrderItemViewModel)addedItem).OtherItems = new List<OrderItemViewModel>();
                                BuildGroupedItems(selectedProduct.items, ((OrderItemViewModel)addedItem), GroupTypes.Others);
                            }
                        }
                        OrderBillViewModel.BillItems.Add(addedItem);
						OrderBillViewModel.OnPropertyChanged(nameof(OrderBillViewModel.HasNoItems));
					};
					if(item.HasCustomItems)
					{
						item.OnDisplayCustomItems += () =>
						{
							CurrentDetailsView = OrderDetailsDataModel.OrderCustmItems;
							IsNavigate = true;

							ItemCustomizationViewModel.CustomItems.Clear();
							ItemCustomizationViewModel.Title = item.ItemName;

							if (item.BasicItems.Any())
                                foreach (var basicItem in item.BasicItems)
                                    ItemCustomizationViewModel.CustomItems.Add(basicItem);
                            if (item.ExtraItems.Any())
                                foreach (var extraItem in item.ExtraItems)
                                    ItemCustomizationViewModel.CustomItems.Add(extraItem);
                            if (item.RemovedItems.Any())
                                foreach (var removedItem in item.RemovedItems)
                                    ItemCustomizationViewModel.CustomItems.Add(removedItem);
                            if (item.OtherItems.Any())
                                foreach (var otherItem in item.OtherItems)
                                    ItemCustomizationViewModel.CustomItems.Add(otherItem);

                        };
                    }
				}
			}
			else if (e.Action == NotifyCollectionChangedAction.Remove)
			{
				foreach (var item in e.OldItems)
				{

				}
			}
		}
		private void BuildGroupedItems(List<ItemDto> items, OrderItemViewModel selectedItem, GroupTypes type)
		{
            foreach (var item in items)
            {
                var createdItem = new OrderItemViewModel() { GroupItems = new List<CustomItemViewModel>() };
                if (type == GroupTypes.Basic)
				{
					createdItem.CustomItemTitle = "Basic";
                    selectedItem.BasicItems.Add(createdItem);
                }
				else if(type == GroupTypes.Extra)
				{
                    createdItem.CustomItemTitle = "Extra";
                    selectedItem.ExtraItems.Add(createdItem);
                }
                else if (type == GroupTypes.Removed)
				{
                    createdItem.CustomItemTitle = "Removed";
                    selectedItem.RemovedItems.Add(createdItem);
                }
                else
				{
                    createdItem.CustomItemTitle = "Others";
                    selectedItem.OtherItems.Add(createdItem);
                }

                foreach (var GroupItem in item.group_items)
                    createdItem.GroupItems.Add(new CustomItemViewModel() { Id = GroupItem.id, Name = GroupItem.name });
            }
        }

		#endregion

		#region PUBLIC METHODS

		#endregion

		#region ACTIONS


		#endregion
	}

	public enum GroupTypes
	{
		Basic,
		Extra,
		Removed,
		Others
	}
}
