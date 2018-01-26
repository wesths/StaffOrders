namespace StaffOrder.Interface.ServiceModels
{
    public class SaveOrderContactDetailsRequest
    {
        public int OrderId { get; set; }
        public string ContactName { get; set; }
        public string ContactNo { get; set; }
        public string ExtNo { get; set; }
    }
}