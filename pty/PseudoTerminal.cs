//
// PseudoTerminal.cs: A managed binding to create Unix Psuedo Terminals
//
// Author: Miguel de Icaza (miguel@gnome.org)
//
// Copyright 2009, Novell, Inc.
//
// This code is licensed under the MIT X11 license, but the library
// it P/Invokes is LGPL v2
//
using System;
using System.Runtime.InteropServices;

namespace Unix {

	public class PseudoTerminal : IDisposable {
		[DllImport ("ptysharp.so.0")]
		extern static int _pty_sharp_open (out int pid_t_child,
						 string [] env_add,
						 string command,
						 string [] argv,
						 string directory,
						 int columns, int rows,
						 int lastlog,
						 int utmp,
						 int wtmp);

		[DllImport ("ptysharp.so.0")]
		extern static int _pty_sharp_get_size (int master, out int columns, out int rows);
		
		[DllImport ("ptysharp.so.0")]
		extern static int _pty_sharp_set_size (int master, int columns, int rows);

		[DllImport ("ptysharp.so.0")]
		extern static void _pty_sharp_set_utf8 (int pty, int utf8);

		[DllImport ("ptysharp.so.0")]
		extern static void _pty_sharp_close(int pty);

		int fd;
		int child_pid;

		public int ChildPid {
			get { return child_pid; }
		}

		public int FileDescriptor {
			get {
				return fd;
			}
		}
			
		internal PseudoTerminal (int fd, int child_pid)
		{
			this.fd = fd;
			this.child_pid = child_pid;
		}

		public static PseudoTerminal Open (string [] env_add, string command, string [] argv, string dir, int columns, int rows, bool lastlog, bool utmp, bool wtmp)
		{
			int child_pid, fd;
			
			fd = _pty_sharp_open (out child_pid, env_add, command, argv, dir, columns, rows, lastlog ? 1 : 0, utmp ? 1 : 0, wtmp ? 1 : 0);
			if (fd == -1)
				return null;

			return new PseudoTerminal (fd, child_pid);
		}

		//
		// True on success, false on failure
		//
		public bool GetSize (out int cols, out int rows)
		{
			return _pty_sharp_get_size (fd, out cols, out rows) == 0;
		}

		public bool SetSize (int cols, int rows)
		{
			return _pty_sharp_set_size (fd, cols, rows) == 0;
		}

		public void SetUTF8 (bool status)
		{
			_pty_sharp_set_utf8 (fd, status ? 1 : 0);
		}

		public void Dispose()
		{
			Dispose(true);

			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose (bool disposing)
		{
			if (fd == -1)
				return;
			_pty_sharp_close (fd);
			fd = -1;
		}

		~PseudoTerminal ()
		{
			Dispose (false);
		}
	}
}