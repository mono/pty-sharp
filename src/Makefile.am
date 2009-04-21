
lib_LTLIBRARIES = libptysharp.la

libptysharp_la_SOURCES = pty.c pty.h

libptysharp_la_CFLAGS = $(GLIB_CFLAGS)
libptysharp_la_LIBADD = $(GLIB_LDADD)

AM_CPPFLAGS = -DLIBEXECDIR='"$(libexecdir)"' 
