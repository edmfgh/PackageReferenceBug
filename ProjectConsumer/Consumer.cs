using ProjectWithContent; // Error: Cannot resolve symbol
using ProjectWithoutContent; // No error

namespace ProjectConsumer
{
    public class Consumer
    {
        public void DoesNotCompile()
        {
            new WithContent().DoStuff(); // Error: ...could not found (are you missing a using directive or an assembly reference?)
            new WithoutContent().DoStuff(); // No error
        }
    }
}