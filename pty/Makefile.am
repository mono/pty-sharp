monodir = $(libdir)/mono/unix
noinst_DATA = pty-sharp.dll sample.exe

EXTRA_DIST = pty-sharp.snk

sources = PseudoTerminal.cs AssemblyInfo.cs

pty-sharp.dll: $(sources)
	gmcs -target:library -out:pty-sharp.dll $(sources)

sample.exe: pty-sharp.dll sample.cs
	gmcs sample.cs -r:pty-sharp.dll -r:Mono.Posix

install-data-local: pty-sharp.dll
	gacutil -i pty-sharp.dll -package unix