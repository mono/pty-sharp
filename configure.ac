AC_PREREQ(2.56)
AC_INIT(pty-sharp, [1.0])
AC_CONFIG_SRCDIR([src/pty.c])
AM_INIT_AUTOMAKE(1.6)
AM_CONFIG_HEADER([config.h])

AC_ISC_POSIX
AC_PROG_CC
AC_STDC_HEADERS
AM_PROG_CC_STDC
AM_MAINTAINER_MODE
AC_PROG_LIBTOOL
PKG_CHECK_MODULES(GLIB,glib-2.0 > 2.9.0)

AC_CHECK_FUNCS(getpt grantpt unlockpt ptsname ptsname_r)
AC_CHECK_FUNC(socket,[have_socket=1],AC_CHECK_LIB(socket,socket,[have_socket=1; LIBS="$LIBS -lsocket"]))
AC_CHECK_FUNC(socketpair,[have_socketpair=1],AC_CHECK_LIB(socket,socketpair,[have_socketpair=1; LIBS="$LIBS -lsocket"]))
AC_CHECK_FUNC(recvmsg,[have_recvmsg=1],AC_CHECK_LIB(socket,recvmsg,[have_recvmsg=1; LIBS="$LIBS -lsocket -lnsl"]))
if test x$have_socket = x1 ; then
	AC_DEFINE(HAVE_SOCKET,1,[Define if you have the socket function.])
fi
if test x$have_socketpair = x1 ; then
	AC_DEFINE(HAVE_SOCKETPAIR,1,[Define if you have the socketpair function.])
fi
if test x$have_recvmsg = x1 ; then
	AC_DEFINE(HAVE_RECVMSG,1,[Define if you have the recvmsg function.])
fi

AC_CHECK_HEADERS(sys/select.h sys/syslimits.h sys/termios.h sys/un.h stropts.h termios.h)

AC_ARG_ENABLE(gnome-pty-helper, [AS_HELP_STRING(--enable-gnome-pty-helper,Build a setuid helper for opening ptys [default=no])], enable_gnome_pty_helper="$enableval", enable_gnome_pty_helper=yes)
if test "$enable_gnome_pty_helper" != no; then
	AC_DEFINE(VTE_USE_GNOME_PTY_HELPER,1,[Define if you intend to use gnome-pty-helper.])
	AC_CONFIG_SUBDIRS(gnome-pty-helper)
fi
AM_CONDITIONAL(BUILD_GNOME_PTY_HELPER,[test "$enable_gnome_pty_helper" != no])

AC_CONFIG_FILES([
Makefile
src/Makefile
pty/Makefile
pty-sharp.pc
])
AC_OUTPUT
