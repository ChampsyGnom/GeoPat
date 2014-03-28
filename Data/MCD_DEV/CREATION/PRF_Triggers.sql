/*################################################################################################*/
/* Script     : PRF_Triggers.sql                                                                  */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

-- Declaration du package d'integrite
Create or replace package IntegrityPackage AS
  Procedure InitNestLevel;
  Function GetNestLevel return number;
  Procedure NextNestLevel;
  Procedure PreviousNestLevel;
End IntegrityPackage;
/

-- Definition du package d'integrite
Create or replace package body IntegrityPackage AS
  NestLevel number;
  -- Procédure initialisant le niveau d'imbrication des triggers
  Procedure InitNestLevel is
  Begin
    NestLevel := 0;
  End;

  -- Fonction retournant le niveau d'imbrication des triggers
  Function GetNestLevel return number is
  Begin
    If NestLevel Is Null Then
      NestLevel := 0;
    End if;
    Return(NestLevel);
  End;

  -- Procédure augmentant le niveau d'imbrication des triggers
  Procedure NextNestLevel is
  Begin
  If NestLevel Is Null Then
    NestLevel := 0;
   End if;
   NestLevel := NestLevel + 1;
  End;

  -- Procédure diminuant le niveau d'imbrication des triggers
  Procedure PreviousNestLevel is
  Begin
    NestLevel := NestLevel - 1;
  End;

End IntegrityPackage;
/


create or replace TRIGGER "PRF"."TIB_BMPROFILTABLE" before insert
on PRF.BM_PROFIL_TABLE for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "PRF.BM_PROFIL"
	cursor c1_bm_profil_table(Vbm_profil__profil varchar) is
		select 1 
		from PRF.BM_PROFIL 
		where 
		PROFIL = Vbm_profil__profil and Vbm_profil__profil is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "PRF.BM_TABLE"
	cursor c2_bm_profil_table(Vbm_table__nom varchar) is
		select 1 
		from PRF.BM_TABLE 
		where 
		NOM = Vbm_table__nom and Vbm_table__nom is not null;
begin

	
	--  Le parent "PRF.BM_PROFIL" doit exister à la création d'un enfant dans "PRF.BM_PROFIL_TABLE"
	if :new.BM_PROFIL__PROFIL is not null then 
		open c1_bm_profil_table ( :new.BM_PROFIL__PROFIL);
		fetch c1_bm_profil_table into dummy;
		found := c1_bm_profil_table%FOUND;
		close c1_bm_profil_table;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "PRF.BM_PROFIL". Impossible de créer un enfant dans "PRF.BM_PROFIL_TABLE".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "PRF.BM_TABLE" doit exister à la création d'un enfant dans "PRF.BM_PROFIL_TABLE"
	if :new.BM_TABLE__NOM is not null then 
		open c2_bm_profil_table ( :new.BM_TABLE__NOM);
		fetch c2_bm_profil_table into dummy;
		found := c2_bm_profil_table%FOUND;
		close c2_bm_profil_table;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "PRF.BM_TABLE". Impossible de créer un enfant dans "PRF.BM_PROFIL_TABLE".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "PRF"."TUB_BMPROFILTABLE" before update
on PRF.BM_PROFIL_TABLE for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "PRF.BM_PROFIL"
	cursor c1_bm_profil_table (Vbm_profil__profil varchar) is
		select 1 
		from PRF.BM_PROFIL 
		where 
		PROFIL = Vbm_profil__profil and Vbm_profil__profil is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "PRF.BM_TABLE"
	cursor c2_bm_profil_table (Vbm_table__nom varchar) is
		select 1 
		from PRF.BM_TABLE 
		where 
		NOM = Vbm_table__nom and Vbm_table__nom is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "PRF.BM_PROFIL" doit exister à la création d'un enfant dans "PRF.BM_PROFIL_TABLE"
	if :new.BM_PROFIL__PROFIL is not null and seq = 0 then 
		open c1_bm_profil_table ( :new.BM_PROFIL__PROFIL);
		fetch c1_bm_profil_table into dummy;
		found := c1_bm_profil_table%FOUND;
		close c1_bm_profil_table;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "PRF.BM_PROFIL". Impossible de modifier un enfant dans "PRF.BM_PROFIL_TABLE".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "PRF.BM_TABLE" doit exister à la création d'un enfant dans "PRF.BM_PROFIL_TABLE"
	if :new.BM_TABLE__NOM is not null and seq = 0 then 
		open c2_bm_profil_table ( :new.BM_TABLE__NOM);
		fetch c2_bm_profil_table into dummy;
		found := c2_bm_profil_table%FOUND;
		close c2_bm_profil_table;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "PRF.BM_TABLE". Impossible de modifier un enfant dans "PRF.BM_PROFIL_TABLE".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "PRF"."TIB_BMPROFIL" before insert
on PRF.BM_PROFIL for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "PRF.BM_SCHEMA"
	cursor c1_bm_profil(Vbm_schema__schema varchar) is
		select 1 
		from PRF.BM_SCHEMA 
		where 
		SCHEMA = Vbm_schema__schema and Vbm_schema__schema is not null;
begin

	
	--  Le parent "PRF.BM_SCHEMA" doit exister à la création d'un enfant dans "PRF.BM_PROFIL"
	if :new.BM_SCHEMA__SCHEMA is not null then 
		open c1_bm_profil ( :new.BM_SCHEMA__SCHEMA);
		fetch c1_bm_profil into dummy;
		found := c1_bm_profil%FOUND;
		close c1_bm_profil;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "PRF.BM_SCHEMA". Impossible de créer un enfant dans "PRF.BM_PROFIL".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "PRF"."TUB_BMPROFIL" before update
on PRF.BM_PROFIL for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "PRF.BM_SCHEMA"
	cursor c1_bm_profil (Vbm_schema__schema varchar) is
		select 1 
		from PRF.BM_SCHEMA 
		where 
		SCHEMA = Vbm_schema__schema and Vbm_schema__schema is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "PRF.BM_SCHEMA" doit exister à la création d'un enfant dans "PRF.BM_PROFIL"
	if :new.BM_SCHEMA__SCHEMA is not null and seq = 0 then 
		open c1_bm_profil ( :new.BM_SCHEMA__SCHEMA);
		fetch c1_bm_profil into dummy;
		found := c1_bm_profil%FOUND;
		close c1_bm_profil;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "PRF.BM_SCHEMA". Impossible de modifier un enfant dans "PRF.BM_PROFIL".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "PRF"."TUA_BMPROFIL" after update
of PROFIL
on PRF.BM_PROFIL for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "PRF.BM_PROFIL" dans les enfants "PRF.BM_PROFIL_TABLE"
	if ((updating('PROFIL') and :old.PROFIL != :new.PROFIL)) then 
		update PRF.BM_PROFIL_TABLE
		set BM_PROFIL__PROFIL = :new.PROFIL  
		where BM_PROFIL__PROFIL = :old.PROFIL;
	end if;
	--  Modification du code du parent "PRF.BM_PROFIL" dans les enfants "PRF.BM_USER_PROFIL"
	if ((updating('PROFIL') and :old.PROFIL != :new.PROFIL)) then 
		update PRF.BM_USER_PROFIL
		set BM_PROFIL__PROFIL = :new.PROFIL  
		where BM_PROFIL__PROFIL = :old.PROFIL;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "PRF"."TDA_BMPROFIL" after delete
on PRF.BM_PROFIL for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "PRF.BM_PROFIL_TABLE"
	delete PRF.BM_PROFIL_TABLE
	where BM_PROFIL__PROFIL = :old.PROFIL;
	
	--  Suppression des enfants dans "PRF.BM_USER_PROFIL"
	delete PRF.BM_USER_PROFIL
	where BM_PROFIL__PROFIL = :old.PROFIL;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "PRF"."TIB_BMUSERPROFIL" before insert
on PRF.BM_USER_PROFIL for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "PRF.BM_USER"
	cursor c1_bm_user_profil(Vbm_user__login varchar) is
		select 1 
		from PRF.BM_USER 
		where 
		LOGIN = Vbm_user__login and Vbm_user__login is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "PRF.BM_PROFIL"
	cursor c2_bm_user_profil(Vbm_profil__profil varchar) is
		select 1 
		from PRF.BM_PROFIL 
		where 
		PROFIL = Vbm_profil__profil and Vbm_profil__profil is not null;
begin

	
	--  Le parent "PRF.BM_USER" doit exister à la création d'un enfant dans "PRF.BM_USER_PROFIL"
	if :new.BM_USER__LOGIN is not null then 
		open c1_bm_user_profil ( :new.BM_USER__LOGIN);
		fetch c1_bm_user_profil into dummy;
		found := c1_bm_user_profil%FOUND;
		close c1_bm_user_profil;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "PRF.BM_USER". Impossible de créer un enfant dans "PRF.BM_USER_PROFIL".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "PRF.BM_PROFIL" doit exister à la création d'un enfant dans "PRF.BM_USER_PROFIL"
	if :new.BM_PROFIL__PROFIL is not null then 
		open c2_bm_user_profil ( :new.BM_PROFIL__PROFIL);
		fetch c2_bm_user_profil into dummy;
		found := c2_bm_user_profil%FOUND;
		close c2_bm_user_profil;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "PRF.BM_PROFIL". Impossible de créer un enfant dans "PRF.BM_USER_PROFIL".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "PRF"."TUB_BMUSERPROFIL" before update
on PRF.BM_USER_PROFIL for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "PRF.BM_USER"
	cursor c1_bm_user_profil (Vbm_user__login varchar) is
		select 1 
		from PRF.BM_USER 
		where 
		LOGIN = Vbm_user__login and Vbm_user__login is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "PRF.BM_PROFIL"
	cursor c2_bm_user_profil (Vbm_profil__profil varchar) is
		select 1 
		from PRF.BM_PROFIL 
		where 
		PROFIL = Vbm_profil__profil and Vbm_profil__profil is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "PRF.BM_USER" doit exister à la création d'un enfant dans "PRF.BM_USER_PROFIL"
	if :new.BM_USER__LOGIN is not null and seq = 0 then 
		open c1_bm_user_profil ( :new.BM_USER__LOGIN);
		fetch c1_bm_user_profil into dummy;
		found := c1_bm_user_profil%FOUND;
		close c1_bm_user_profil;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "PRF.BM_USER". Impossible de modifier un enfant dans "PRF.BM_USER_PROFIL".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "PRF.BM_PROFIL" doit exister à la création d'un enfant dans "PRF.BM_USER_PROFIL"
	if :new.BM_PROFIL__PROFIL is not null and seq = 0 then 
		open c2_bm_user_profil ( :new.BM_PROFIL__PROFIL);
		fetch c2_bm_user_profil into dummy;
		found := c2_bm_user_profil%FOUND;
		close c2_bm_user_profil;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "PRF.BM_PROFIL". Impossible de modifier un enfant dans "PRF.BM_USER_PROFIL".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "PRF"."TUA_BMSCHEMA" after update
of SCHEMA
on PRF.BM_SCHEMA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "PRF.BM_SCHEMA" dans les enfants "PRF.BM_TABLE"
	if ((updating('SCHEMA') and :old.SCHEMA != :new.SCHEMA)) then 
		update PRF.BM_TABLE
		set BM_SCHEMA__SCHEMA = :new.SCHEMA  
		where BM_SCHEMA__SCHEMA = :old.SCHEMA;
	end if;
	--  Modification du code du parent "PRF.BM_SCHEMA" dans les enfants "PRF.BM_PROFIL"
	if ((updating('SCHEMA') and :old.SCHEMA != :new.SCHEMA)) then 
		update PRF.BM_PROFIL
		set BM_SCHEMA__SCHEMA = :new.SCHEMA  
		where BM_SCHEMA__SCHEMA = :old.SCHEMA;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "PRF"."TDA_BMSCHEMA" after delete
on PRF.BM_SCHEMA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "PRF.BM_TABLE"
	delete PRF.BM_TABLE
	where BM_SCHEMA__SCHEMA = :old.SCHEMA;
	
	--  Suppression des enfants dans "PRF.BM_PROFIL"
	delete PRF.BM_PROFIL
	where BM_SCHEMA__SCHEMA = :old.SCHEMA;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "PRF"."TIB_BMTABLE" before insert
on PRF.BM_TABLE for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "PRF.BM_SCHEMA"
	cursor c1_bm_table(Vbm_schema__schema varchar) is
		select 1 
		from PRF.BM_SCHEMA 
		where 
		SCHEMA = Vbm_schema__schema and Vbm_schema__schema is not null;
begin

	
	--  Le parent "PRF.BM_SCHEMA" doit exister à la création d'un enfant dans "PRF.BM_TABLE"
	if :new.BM_SCHEMA__SCHEMA is not null then 
		open c1_bm_table ( :new.BM_SCHEMA__SCHEMA);
		fetch c1_bm_table into dummy;
		found := c1_bm_table%FOUND;
		close c1_bm_table;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "PRF.BM_SCHEMA". Impossible de créer un enfant dans "PRF.BM_TABLE".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "PRF"."TUB_BMTABLE" before update
on PRF.BM_TABLE for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "PRF.BM_SCHEMA"
	cursor c1_bm_table (Vbm_schema__schema varchar) is
		select 1 
		from PRF.BM_SCHEMA 
		where 
		SCHEMA = Vbm_schema__schema and Vbm_schema__schema is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "PRF.BM_SCHEMA" doit exister à la création d'un enfant dans "PRF.BM_TABLE"
	if :new.BM_SCHEMA__SCHEMA is not null and seq = 0 then 
		open c1_bm_table ( :new.BM_SCHEMA__SCHEMA);
		fetch c1_bm_table into dummy;
		found := c1_bm_table%FOUND;
		close c1_bm_table;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "PRF.BM_SCHEMA". Impossible de modifier un enfant dans "PRF.BM_TABLE".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "PRF"."TUA_BMTABLE" after update
of NOM
on PRF.BM_TABLE for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "PRF.BM_TABLE" dans les enfants "PRF.BM_PROFIL_TABLE"
	if ((updating('NOM') and :old.NOM != :new.NOM)) then 
		update PRF.BM_PROFIL_TABLE
		set BM_TABLE__NOM = :new.NOM  
		where BM_TABLE__NOM = :old.NOM;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "PRF"."TDA_BMTABLE" after delete
on PRF.BM_TABLE for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "PRF.BM_PROFIL_TABLE"
	delete PRF.BM_PROFIL_TABLE
	where BM_TABLE__NOM = :old.NOM;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "PRF"."TUA_BMUSER" after update
of LOGIN
on PRF.BM_USER for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "PRF.BM_USER" dans les enfants "PRF.BM_USER_PROFIL"
	if ((updating('LOGIN') and :old.LOGIN != :new.LOGIN)) then 
		update PRF.BM_USER_PROFIL
		set BM_USER__LOGIN = :new.LOGIN  
		where BM_USER__LOGIN = :old.LOGIN;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "PRF"."TDA_BMUSER" after delete
on PRF.BM_USER for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "PRF.BM_USER_PROFIL"
	delete PRF.BM_USER_PROFIL
	where BM_USER__LOGIN = :old.LOGIN;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


