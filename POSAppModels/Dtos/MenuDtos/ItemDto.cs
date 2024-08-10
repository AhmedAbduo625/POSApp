
namespace POSAppModels
{
	public class ItemDto
	{
        public int id { get; set; }
        public string name { get; set; }
		public decimal price { get; set; }
		public List<ItemDto> level2 { get; set; } 
		public List<ItemDto> items { get; set; }
        public List<ItemDto> addItems { get; set; } // == 
        public List<ItemDto> deleteItems { get; set; } // == 
        public List<ItemDto> isbasic { get; set; } // == 
        public List<CustomItemDto> group_items { get; set; }
    }
}
