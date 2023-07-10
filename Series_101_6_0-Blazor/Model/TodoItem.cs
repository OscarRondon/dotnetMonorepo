namespace Series_101_6_0_Blazor.Model
{
    public class TodoItem
    {
        public string Id { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmssffff");
        public string Todo { get; set; }
        public DateTime ?DueDate { get; set; }
    }
}
