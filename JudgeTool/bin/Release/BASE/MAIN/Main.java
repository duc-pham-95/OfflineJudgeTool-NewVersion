import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.StringTokenizer;

public class Main {

	public static void main(String[] args) throws IOException {
		InputReader sc = new InputReader(System.in);
		int n = sc.nextInt();
		int m = sc.nextInt();
		int c = sc.nextInt();
		HashMap<Integer, Integer> hs = new HashMap<Integer, Integer>();
		int count = 0;
		for (int i = 0; i < n; i++) {
			int x = sc.nextInt();
			if (!hs.containsKey(x)) {
				hs.put(x, 1);
			} else {
				hs.put(x, hs.get(x) +1);
			}
		}
		ArrayList<Integer>arr=new ArrayList<Integer>(hs.keySet());
		for (int i = 0; i < m; i++) {
			int a = sc.nextInt();
			for (int j=0;j<arr.size();j++) {
				if (a >= arr.get(j) && a - arr.get(j) <= c) {
					count+=hs.get(arr.get(j));
					hs.remove(arr.get(j));
					arr.remove(arr.get(j));		
					
				}
			}
		}

		System.out.println(n-hs.size());
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
