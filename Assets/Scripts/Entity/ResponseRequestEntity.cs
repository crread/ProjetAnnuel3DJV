namespace Entity
{
    public class ResponseRequestEntity
    {
        public long httpCode;
        public readonly string detail;

        public ResponseRequestEntity(string detail)
        {
            this.detail = detail;
        }
    }
}
