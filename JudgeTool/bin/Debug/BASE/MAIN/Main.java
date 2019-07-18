import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.StringTokenizer;

class Student implements Comparable<Student>
{
    long id;
    String name;
    int average = 0;

    public Student(long id, String name) {
        this.id = id;
        this.name = name;
    }

    @Override
    public int compareTo(Student t) {
       if(this.average > t.average)
       {
           return -1;
       }
       else if(this.average < t.average)
       {
           return 1;
       }
       else
       {
           if(this.id > t.id)
           {
               return 1;
           }
           else if(this.id < t.id)
           {
               return -1;
           }
           else
           {
               return 0;
           }
       }
    }

    @Override
    public String toString() {
        return this.id + " " + this.name + " " + this.average;
    }
    



   
    
    
}
public class Main {

       
	public static void main(String[] args) {
		InputReader ip = new InputReader(System.in);
                int n = ip.nextInt();
                int m = ip.nextInt();
                ArrayList<Student> list = new ArrayList<>();
                for(int i = 0; i < n; i++)
                {
                    Student s = new Student(ip.nextLong(), ip.next());
                    int c = ip.nextInt();
                    int p = 0;
                    int count = 0;
                    int sum = 0;
                    for(int j = 0; j < c; j++)
                    {
                        int temp = ip.nextInt();
                        if(temp >= 50)
                        {
                            p += 4;
                            count++;
                            sum += temp;
                        }
                    }
                    if(p >= m)
                    {
                        s.average = sum / count;
                        list.add(s);
                    }
                }
                Collections.sort(list);
                for(Student temp : list)
                {
                    System.out.println(temp);
                }
             
                
	}

	static class InputReader {
		StringTokenizer tokenizer;
		BufferedReader reader;
		String token;
		String temp;

		public InputReader(InputStream stream) {
			tokenizer = null;
			reader = new BufferedReader(new InputStreamReader(stream));
		}

		public InputReader(FileInputStream stream) {
			tokenizer = null;
			reader = new BufferedReader(new InputStreamReader(stream));
		}

		public String nextLine() throws IOException {
			return reader.readLine();
		}

		public String next() {
			while (tokenizer == null || !tokenizer.hasMoreTokens()) {
				try {
					if (temp != null) {
						tokenizer = new StringTokenizer(temp);
						temp = null;
					} else {
						tokenizer = new StringTokenizer(reader.readLine());
					}

				} catch (IOException e) {
				}
			}
			return tokenizer.nextToken();
		}

		public double nextDouble() {
			return Double.parseDouble(next());
		}

		public int nextInt() {
			return Integer.parseInt(next());
		}

		public long nextLong() {
			return Long.parseLong(next());
		}
	}
}
