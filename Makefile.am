SUBDIRS = src pty

EXTRA_DIST = pty-sharp.pc.in 

pkgconfigdir = $(libdir)/pkgconfig
pkgconfig_DATA = pty-sharp.pc

if BUILD_GNOME_PTY_HELPER
SUBDIRS += gnome-pty-helper
endif
