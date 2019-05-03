namespace OnBoarding.Contract
{
    public class Response<T>
    {
        public int TotalNumberOfRecords { get; set; }

        public T Result { get; set; }
    }
}
