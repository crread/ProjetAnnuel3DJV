namespace Entity
{
    public class ResponseRequestEntity
    {
        public long httpCode;
        public string detail;

        public ResponseRequestEntity() {}

        public ResponseRequestEntity(string detail)
        {
            this.detail = detail;
        }
    }
}
