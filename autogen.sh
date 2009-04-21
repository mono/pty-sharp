autoheader
libtoolize --force
aclocal
automake --add-missing
autoconf
(cd gnome-pty-helper; sh ./autogen.sh $*)
./configure $*