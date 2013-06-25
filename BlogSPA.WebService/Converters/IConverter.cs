namespace BlogSPA.WebService.Converters
{
    public interface IConverter<TSource, TTarget>
    {
        void Convert(TSource source, TTarget target);
        void ConvertBack(TTarget source, TSource target);
    }
}