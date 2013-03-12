namespace Samples.Readable
{
public  class CodeCleanupSample
{
public static  int Fibonacci( int n)
{
        int a =  0; int b  = 1;
        // In N steps compute Fibonacci sequence iteratively.
        for (int i = 0; i < n; i++){int temp = a;a = b;b = temp + b;}
         return a;





    }
     }
    }

// Ctrl + EF
// Review config settings and reapply
// Talk about settings on a local/project/team level