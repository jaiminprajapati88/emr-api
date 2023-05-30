namespace EMR.Data.Model.Config
{
    public class MessageModel
    {
        public string MessageId { get; set; } = null!;

        public string MessageDesc { get; set; } = null!;

        public int MessageTypeCode { get; set; }

        public bool IsActive { get; set; }
    }
}
