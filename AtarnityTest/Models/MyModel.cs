using System;
namespace AtarnityTest.Models
{
  public class MyModel
  {
    public MyModel(string nameX, int idX)
    {
      id = idX;
      name = nameX;
    }

    public string name { get; set; }
    public int id { get; set; }
  }
}
