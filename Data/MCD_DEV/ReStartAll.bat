@Echo OFF
SET ORACLE_SID=MCDDEV
set INPUT=
set /P INPUT=Chemin complet de SqlPlus.exe: %=%
@Echo ON
set echo on
echo exit | "%INPUT%" /nolog @RestartAll.sql
pause
