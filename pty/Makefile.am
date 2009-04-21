monodir = $(libdir)/mono/unix
noinst_DATA = pty-sharp.dll

EXTRA_DIST = pty-sharp.snk

sources = PseudoTerminal.cs AssemblyInfo.cs

pty-sharp.dll: $(sources)
	gmcs -target:library -out:pty-sharp.dll $(sources)

install-data-local: pty-sharp.dll
	gacutil -i pty-sharp.dll -package unix