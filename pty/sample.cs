//
// This sample that shows how to use the PseudoTerminal class, it
// is a quick hack, this is now how you should to things (using
// two threads is just poor taste, but it illustrates what this does).
//
using System;
using Unix;
using Mono.Unix;
using System.IO;
using System.Threading;

class X {
	static void Main ()
	{
		var pty = PseudoTerminal.Open (null,
					       "/bin/bash",
					       new string [] { "/bin/bash" },
					       "/tmp",
					       80, 24, false, false, false);

		var x = Console.ForegroundColor;

		//
		// OK, this is a disgusting hack (2 threads instead of non-blocking
		// io) but it is merely a test driver
		//
		var us = new UnixStream (pty.FileDescriptor, false);
		var sw = new StreamWriter (us);
		new Thread (delegate (object p) {
			byte [] b = new byte [1024];
			int n;
			
			while ((n = us.Read (b, 0, b.Length)) != 0){
				for (int i = 0; i < n; i++)
					Console.Write ((char) b [i]);
			}
		}).Start ();
		
		while (true){
			ConsoleKeyInfo k = Console.ReadKey (true);
			sw.Write (k.KeyChar);
			sw.Flush ();
		}
	}
}
