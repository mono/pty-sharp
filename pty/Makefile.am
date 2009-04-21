monodir = $(libdir)/mono/unix
noinst_DATA = pty-sharp.dll sample.exe

sources = PseudoTerminal.cs AssemblyInfo.cs 

EXTRA_DIST = pty-sharp.snk $(sources) sample.cs

DISTCLEANFILES = sample.exe pty-sharp.snk pty-sharp.dll

pty-sharp.dll: $(sources)
	-cp $(srcdir)/pty-sharp.snk .
	gmcs -target:library -out:pty-sharp.dll $(addprefix $(srcdir)/, $(sources))

sample.exe: pty-sharp.dll sample.cs
	gmcs $(srcdir)/sample.cs -out:sample.exe -r:pty-sharp.dll -r:Mono.Posix

install-data-local: pty-sharp.dll
	gacutil -i pty-sharp.dll -package unix