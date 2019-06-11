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


public class Main {

       
	public static void main(String[] args) {
		InputReader ip = new InputReader(System.in);
                int n = ip.nextInt();
                int m = ip.nextInt();
                HashMap<String, String> hm = new HashMap<>();
                for(int i = 0; i < m; i++)
                {
                    hm.put(ip.next(), ip.next());
                }
                for(int i = 0; i < n; i++)
                {
                    String s = ip.next();
                    if(hm.containsKey(s))
                    {
                        if(hm.get(s).length() < s.length())
                        {
                            System.out.print(hm.get(s)+" ");
                        }
                        else
                        {
                            System.out.print(s+ " ");
                        }
                    }
                   
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
