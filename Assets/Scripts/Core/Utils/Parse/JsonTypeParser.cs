namespace Core.Utils.Parse
{
    public class JsonTypeParser<T> where T:struct
    {
        private T value;
        private string jsonValue;
        private bool isParsed;

        public T Value
        {
            get
            {
                if (!isParsed)
                {
                    isParsed = true;
                    ParseUtil.TryParse(jsonValue, out value);
                }

                return value;
            }
        }

        public JsonTypeParser(string jsonValue)
        {
            this.jsonValue = jsonValue;
        }
    }
}