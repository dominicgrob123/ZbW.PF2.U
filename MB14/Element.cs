namespace MB14
{
  public class Element<T>
  {

    public Element(string key, T value, bool isDeleted = false)
    {
      Key = key;
      Value = value;
      IsDeleted = isDeleted;
    }

    public string Key { get; set; }

    public T Value { get; set; }

    public bool IsDeleted { get; internal set; }
  }
}
