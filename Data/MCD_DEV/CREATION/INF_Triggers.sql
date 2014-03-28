/*################################################################################################*/
/* Script     : INF_Triggers.sql                                                                  */
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


create or replace TRIGGER "INF"."TIB_ACCIDENTINF" before insert
on INF.ACCIDENT_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_accident_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.ACCIDENT_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c1_accident_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_accident_inf into dummy;
		found := c1_accident_inf%FOUND;
		close c1_accident_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.ACCIDENT_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_ACCIDENTINF" before update
on INF.ACCIDENT_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_accident_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.ACCIDENT_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c1_accident_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_accident_inf into dummy;
		found := c1_accident_inf%FOUND;
		close c1_accident_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.ACCIDENT_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_AIREINF" before insert
on INF.AIRE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_AIRE_INF"
	cursor c1_aire_inf(Vcd_aire_inf__type varchar) is
		select 1 
		from INF.CD_AIRE_INF 
		where 
		TYPE = Vcd_aire_inf__type and Vcd_aire_inf__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c2_aire_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	
	--  Le parent "INF.CD_AIRE_INF" doit exister à la création d'un enfant dans "INF.AIRE_INF"
	if :new.CD_AIRE_INF__TYPE is not null then 
		open c1_aire_inf ( :new.CD_AIRE_INF__TYPE);
		fetch c1_aire_inf into dummy;
		found := c1_aire_inf%FOUND;
		close c1_aire_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_AIRE_INF". Impossible de créer un enfant dans "INF.AIRE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.AIRE_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c2_aire_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c2_aire_inf into dummy;
		found := c2_aire_inf%FOUND;
		close c2_aire_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.AIRE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_AIREINF" before update
on INF.AIRE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_AIRE_INF"
	cursor c1_aire_inf (Vcd_aire_inf__type varchar) is
		select 1 
		from INF.CD_AIRE_INF 
		where 
		TYPE = Vcd_aire_inf__type and Vcd_aire_inf__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c2_aire_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CD_AIRE_INF" doit exister à la création d'un enfant dans "INF.AIRE_INF"
	if :new.CD_AIRE_INF__TYPE is not null and seq = 0 then 
		open c1_aire_inf ( :new.CD_AIRE_INF__TYPE);
		fetch c1_aire_inf into dummy;
		found := c1_aire_inf%FOUND;
		close c1_aire_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_AIRE_INF". Impossible de modifier un enfant dans "INF.AIRE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.AIRE_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c2_aire_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c2_aire_inf into dummy;
		found := c2_aire_inf%FOUND;
		close c2_aire_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.AIRE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUA_AIREINF" after update
of LIAISON_INF__LIAISON,CD_AIRE_INF__TYPE,CHAUSSEE_INF__SENS,ABS_DEB
on INF.AIRE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.AIRE_INF" dans les enfants "INF.AIRE__PRESTATAIRE_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('CD_AIRE_INF__TYPE') and :old.CD_AIRE_INF__TYPE != :new.CD_AIRE_INF__TYPE) or 
	(updating('CHAUSSEE_INF__SENS') and :old.CHAUSSEE_INF__SENS != :new.CHAUSSEE_INF__SENS) or 
	(updating('ABS_DEB') and :old.ABS_DEB != :new.ABS_DEB)) then 
		update INF.AIRE__PRESTATAIRE_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CD_AIRE_INF__TYPE = :new.CD_AIRE_INF__TYPE,
		CHAUSSEE_INF__SENS = :new.CHAUSSEE_INF__SENS,
		AIRE_INF__ABS_DEB = :new.ABS_DEB  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CD_AIRE_INF__TYPE = :old.CD_AIRE_INF__TYPE and 
		CHAUSSEE_INF__SENS = :old.CHAUSSEE_INF__SENS and 
		AIRE_INF__ABS_DEB = :old.ABS_DEB;
	end if;
	--  Modification du code du parent "INF.AIRE_INF" dans les enfants "INF.AIRE__SERVICE_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('CD_AIRE_INF__TYPE') and :old.CD_AIRE_INF__TYPE != :new.CD_AIRE_INF__TYPE) or 
	(updating('CHAUSSEE_INF__SENS') and :old.CHAUSSEE_INF__SENS != :new.CHAUSSEE_INF__SENS) or 
	(updating('ABS_DEB') and :old.ABS_DEB != :new.ABS_DEB)) then 
		update INF.AIRE__SERVICE_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CD_AIRE_INF__TYPE = :new.CD_AIRE_INF__TYPE,
		CHAUSSEE_INF__SENS = :new.CHAUSSEE_INF__SENS,
		AIRE_INF__ABS_DEB = :new.ABS_DEB  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CD_AIRE_INF__TYPE = :old.CD_AIRE_INF__TYPE and 
		CHAUSSEE_INF__SENS = :old.CHAUSSEE_INF__SENS and 
		AIRE_INF__ABS_DEB = :old.ABS_DEB;
	end if;
	--  Modification du code du parent "INF.AIRE_INF" dans les enfants "INF.AIRE__PLACE_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('CD_AIRE_INF__TYPE') and :old.CD_AIRE_INF__TYPE != :new.CD_AIRE_INF__TYPE) or 
	(updating('CHAUSSEE_INF__SENS') and :old.CHAUSSEE_INF__SENS != :new.CHAUSSEE_INF__SENS) or 
	(updating('ABS_DEB') and :old.ABS_DEB != :new.ABS_DEB)) then 
		update INF.AIRE__PLACE_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CD_AIRE_INF__TYPE = :new.CD_AIRE_INF__TYPE,
		CHAUSSEE_INF__SENS = :new.CHAUSSEE_INF__SENS,
		AIRE_INF__ABS_DEB = :new.ABS_DEB  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CD_AIRE_INF__TYPE = :old.CD_AIRE_INF__TYPE and 
		CHAUSSEE_INF__SENS = :old.CHAUSSEE_INF__SENS and 
		AIRE_INF__ABS_DEB = :old.ABS_DEB;
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


create or replace TRIGGER "INF"."TDA_AIREINF" after delete
on INF.AIRE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.AIRE__PRESTATAIRE_INF"
	delete INF.AIRE__PRESTATAIRE_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CD_AIRE_INF__TYPE = :old.CD_AIRE_INF__TYPE and 
	CHAUSSEE_INF__SENS = :old.CHAUSSEE_INF__SENS and 
	AIRE_INF__ABS_DEB = :old.ABS_DEB;
	
	--  Suppression des enfants dans "INF.AIRE__SERVICE_INF"
	delete INF.AIRE__SERVICE_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CD_AIRE_INF__TYPE = :old.CD_AIRE_INF__TYPE and 
	CHAUSSEE_INF__SENS = :old.CHAUSSEE_INF__SENS and 
	AIRE_INF__ABS_DEB = :old.ABS_DEB;
	
	--  Suppression des enfants dans "INF.AIRE__PLACE_INF"
	delete INF.AIRE__PLACE_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CD_AIRE_INF__TYPE = :old.CD_AIRE_INF__TYPE and 
	CHAUSSEE_INF__SENS = :old.CHAUSSEE_INF__SENS and 
	AIRE_INF__ABS_DEB = :old.ABS_DEB;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TIB_PROLDINF" before insert
on INF.PR_OLD_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_pr_old_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.PR_OLD_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c1_pr_old_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_pr_old_inf into dummy;
		found := c1_pr_old_inf%FOUND;
		close c1_pr_old_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.PR_OLD_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_PROLDINF" before update
on INF.PR_OLD_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_pr_old_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.PR_OLD_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c1_pr_old_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_pr_old_inf into dummy;
		found := c1_pr_old_inf%FOUND;
		close c1_pr_old_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.PR_OLD_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_BIFURCATIONINF" before insert
on INF.BIFURCATION_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_BIF_INF"
	cursor c1_bifurcation_inf(Vcd_bif_inf__type varchar) is
		select 1 
		from INF.CD_BIF_INF 
		where 
		TYPE = Vcd_bif_inf__type and Vcd_bif_inf__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c2_bifurcation_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	
	--  Le parent "INF.CD_BIF_INF" doit exister à la création d'un enfant dans "INF.BIFURCATION_INF"
	if :new.CD_BIF_INF__TYPE is not null then 
		open c1_bifurcation_inf ( :new.CD_BIF_INF__TYPE);
		fetch c1_bifurcation_inf into dummy;
		found := c1_bifurcation_inf%FOUND;
		close c1_bifurcation_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_BIF_INF". Impossible de créer un enfant dans "INF.BIFURCATION_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.BIFURCATION_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c2_bifurcation_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c2_bifurcation_inf into dummy;
		found := c2_bifurcation_inf%FOUND;
		close c2_bifurcation_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.BIFURCATION_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_BIFURCATIONINF" before update
on INF.BIFURCATION_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_BIF_INF"
	cursor c1_bifurcation_inf (Vcd_bif_inf__type varchar) is
		select 1 
		from INF.CD_BIF_INF 
		where 
		TYPE = Vcd_bif_inf__type and Vcd_bif_inf__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c2_bifurcation_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CD_BIF_INF" doit exister à la création d'un enfant dans "INF.BIFURCATION_INF"
	if :new.CD_BIF_INF__TYPE is not null and seq = 0 then 
		open c1_bifurcation_inf ( :new.CD_BIF_INF__TYPE);
		fetch c1_bifurcation_inf into dummy;
		found := c1_bifurcation_inf%FOUND;
		close c1_bifurcation_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_BIF_INF". Impossible de modifier un enfant dans "INF.BIFURCATION_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.BIFURCATION_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c2_bifurcation_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c2_bifurcation_inf into dummy;
		found := c2_bifurcation_inf%FOUND;
		close c2_bifurcation_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.BIFURCATION_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_BRETELLEINF" before insert
on INF.BRETELLE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_bretelle_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.BRETELLE_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c1_bretelle_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_bretelle_inf into dummy;
		found := c1_bretelle_inf%FOUND;
		close c1_bretelle_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.BRETELLE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_BRETELLEINF" before update
on INF.BRETELLE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_bretelle_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.BRETELLE_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c1_bretelle_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_bretelle_inf into dummy;
		found := c1_bretelle_inf%FOUND;
		close c1_bretelle_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.BRETELLE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_CHAUSSEEINF" before insert
on INF.CHAUSSEE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.LIAISON_INF"
	cursor c1_chaussee_inf(Vliaison_inf__liaison varchar) is
		select 1 
		from INF.LIAISON_INF 
		where 
		LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null;
begin

	
	--  Le parent "INF.LIAISON_INF" doit exister à la création d'un enfant dans "INF.CHAUSSEE_INF"
	if :new.LIAISON_INF__LIAISON is not null then 
		open c1_chaussee_inf ( :new.LIAISON_INF__LIAISON);
		fetch c1_chaussee_inf into dummy;
		found := c1_chaussee_inf%FOUND;
		close c1_chaussee_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.LIAISON_INF". Impossible de créer un enfant dans "INF.CHAUSSEE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_CHAUSSEEINF" before update
on INF.CHAUSSEE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.LIAISON_INF"
	cursor c1_chaussee_inf (Vliaison_inf__liaison varchar) is
		select 1 
		from INF.LIAISON_INF 
		where 
		LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.LIAISON_INF" doit exister à la création d'un enfant dans "INF.CHAUSSEE_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 then 
		open c1_chaussee_inf ( :new.LIAISON_INF__LIAISON);
		fetch c1_chaussee_inf into dummy;
		found := c1_chaussee_inf%FOUND;
		close c1_chaussee_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.LIAISON_INF". Impossible de modifier un enfant dans "INF.CHAUSSEE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUA_CHAUSSEEINF" after update
of LIAISON_INF__LIAISON,SENS
on INF.CHAUSSEE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.PT_SING_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.PT_SING_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.TR_DEC_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.TR_DEC_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.REPERE_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.REPERE_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.PREV_SGE_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.PREV_SGE_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.PK_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.PK_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.TPC_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.TPC_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.PR_OLD_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.PR_OLD_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.SENSIBLE_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.SENSIBLE_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.CLIM_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.CLIM_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.AMENAGEMENT_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.AMENAGEMENT_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.ACCIDENT_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.ACCIDENT_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.CORRESPONDANCE_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.CORRESPONDANCE_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.SECURITE_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.SECURITE_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.OCCUPATION_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.OCCUPATION_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.ECLAIRAGE_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.ECLAIRAGE_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.TALUS_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.TALUS_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.CL_VOIE_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.CL_VOIE_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.TRAFIC_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.TRAFIC_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.PAVE_VOIE_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.PAVE_VOIE_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.SECTION_TRAFIC_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.SECTION_TRAFIC_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.REPARTITION_TRAFIC_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.REPARTITION_TRAFIC_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.GARE_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.GARE_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.AIRE_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.AIRE_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.BIFURCATION_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.BIFURCATION_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
	end if;
	--  Modification du code du parent "INF.CHAUSSEE_INF" dans les enfants "INF.BRETELLE_INF"
	if ((updating('LIAISON_INF__LIAISON') and :old.LIAISON_INF__LIAISON != :new.LIAISON_INF__LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS)) then 
		update INF.BRETELLE_INF
		set LIAISON_INF__LIAISON = :new.LIAISON_INF__LIAISON,
		CHAUSSEE_INF__SENS = :new.SENS  
		where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
		CHAUSSEE_INF__SENS = :old.SENS;
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


create or replace TRIGGER "INF"."TDA_CHAUSSEEINF" after delete
on INF.CHAUSSEE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.PT_SING_INF"
	delete INF.PT_SING_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.TR_DEC_INF"
	delete INF.TR_DEC_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.REPERE_INF"
	delete INF.REPERE_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.PREV_SGE_INF"
	delete INF.PREV_SGE_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.PK_INF"
	delete INF.PK_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.TPC_INF"
	delete INF.TPC_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.PR_OLD_INF"
	delete INF.PR_OLD_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.SENSIBLE_INF"
	delete INF.SENSIBLE_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.CLIM_INF"
	delete INF.CLIM_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.AMENAGEMENT_INF"
	delete INF.AMENAGEMENT_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.ACCIDENT_INF"
	delete INF.ACCIDENT_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.CORRESPONDANCE_INF"
	delete INF.CORRESPONDANCE_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.SECURITE_INF"
	delete INF.SECURITE_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.OCCUPATION_INF"
	delete INF.OCCUPATION_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.ECLAIRAGE_INF"
	delete INF.ECLAIRAGE_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.TALUS_INF"
	delete INF.TALUS_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.CL_VOIE_INF"
	delete INF.CL_VOIE_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.TRAFIC_INF"
	delete INF.TRAFIC_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.PAVE_VOIE_INF"
	delete INF.PAVE_VOIE_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.SECTION_TRAFIC_INF"
	delete INF.SECTION_TRAFIC_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.REPARTITION_TRAFIC_INF"
	delete INF.REPARTITION_TRAFIC_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.GARE_INF"
	delete INF.GARE_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.AIRE_INF"
	delete INF.AIRE_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.BIFURCATION_INF"
	delete INF.BIFURCATION_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	--  Suppression des enfants dans "INF.BRETELLE_INF"
	delete INF.BRETELLE_INF
	where LIAISON_INF__LIAISON = :old.LIAISON_INF__LIAISON and 
	CHAUSSEE_INF__SENS = :old.SENS;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CDCLASSTRAFINF" after update
of CODE
on INF.CD_CLASS_TRAF_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_CLASS_TRAF_INF" dans les enfants "INF.SECTION_TRAFIC_INF"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update INF.SECTION_TRAFIC_INF
		set CD_CLASS_TRAF_INF__CODE = :new.CODE  
		where CD_CLASS_TRAF_INF__CODE = :old.CODE;
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


create or replace TRIGGER "INF"."TDA_CDCLASSTRAFINF" after delete
on INF.CD_CLASS_TRAF_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.SECTION_TRAFIC_INF"
	delete INF.SECTION_TRAFIC_INF
	where CD_CLASS_TRAF_INF__CODE = :old.CODE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CLSINF" after update
of ID
on INF.CLS_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CLS_INF" dans les enfants "INF.CLS_DOC_INF"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update INF.CLS_DOC_INF
		set CLS__ID = :new.ID  
		where CLS__ID = :old.ID;
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


create or replace TRIGGER "INF"."TDA_CLSINF" after delete
on INF.CLS_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.CLS_DOC_INF"
	delete INF.CLS_DOC_INF
	where CLS__ID = :old.ID;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TIB_CLIMINF" before insert
on INF.CLIM_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_CLIM_INF"
	cursor c1_clim_inf(Vcd_clim_inf__code varchar) is
		select 1 
		from INF.CD_CLIM_INF 
		where 
		CODE = Vcd_clim_inf__code and Vcd_clim_inf__code is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c2_clim_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	
	--  Le parent "INF.CD_CLIM_INF" doit exister à la création d'un enfant dans "INF.CLIM_INF"
	if :new.CD_CLIM_INF__CODE is not null then 
		open c1_clim_inf ( :new.CD_CLIM_INF__CODE);
		fetch c1_clim_inf into dummy;
		found := c1_clim_inf%FOUND;
		close c1_clim_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_CLIM_INF". Impossible de créer un enfant dans "INF.CLIM_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.CLIM_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c2_clim_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c2_clim_inf into dummy;
		found := c2_clim_inf%FOUND;
		close c2_clim_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.CLIM_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_CLIMINF" before update
on INF.CLIM_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_CLIM_INF"
	cursor c1_clim_inf (Vcd_clim_inf__code varchar) is
		select 1 
		from INF.CD_CLIM_INF 
		where 
		CODE = Vcd_clim_inf__code and Vcd_clim_inf__code is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c2_clim_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CD_CLIM_INF" doit exister à la création d'un enfant dans "INF.CLIM_INF"
	if :new.CD_CLIM_INF__CODE is not null and seq = 0 then 
		open c1_clim_inf ( :new.CD_CLIM_INF__CODE);
		fetch c1_clim_inf into dummy;
		found := c1_clim_inf%FOUND;
		close c1_clim_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_CLIM_INF". Impossible de modifier un enfant dans "INF.CLIM_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.CLIM_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c2_clim_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c2_clim_inf into dummy;
		found := c2_clim_inf%FOUND;
		close c2_clim_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.CLIM_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_CLSDOCINF" before insert
on INF.CLS_DOC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.DOC_INF"
	cursor c1_cls_doc_inf(Vdoc__id number) is
		select 1 
		from INF.DOC_INF 
		where 
		ID = Vdoc__id and Vdoc__id is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CLS_INF"
	cursor c2_cls_doc_inf(Vcls__id number) is
		select 1 
		from INF.CLS_INF 
		where 
		ID = Vcls__id and Vcls__id is not null;
begin

	
	--  Le parent "INF.DOC_INF" doit exister à la création d'un enfant dans "INF.CLS_DOC_INF"
	if :new.DOC__ID is not null then 
		open c1_cls_doc_inf ( :new.DOC__ID);
		fetch c1_cls_doc_inf into dummy;
		found := c1_cls_doc_inf%FOUND;
		close c1_cls_doc_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.DOC_INF". Impossible de créer un enfant dans "INF.CLS_DOC_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CLS_INF" doit exister à la création d'un enfant dans "INF.CLS_DOC_INF"
	if :new.CLS__ID is not null then 
		open c2_cls_doc_inf ( :new.CLS__ID);
		fetch c2_cls_doc_inf into dummy;
		found := c2_cls_doc_inf%FOUND;
		close c2_cls_doc_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CLS_INF". Impossible de créer un enfant dans "INF.CLS_DOC_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_CLSDOCINF" before update
on INF.CLS_DOC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.DOC_INF"
	cursor c1_cls_doc_inf (Vdoc__id number) is
		select 1 
		from INF.DOC_INF 
		where 
		ID = Vdoc__id and Vdoc__id is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CLS_INF"
	cursor c2_cls_doc_inf (Vcls__id number) is
		select 1 
		from INF.CLS_INF 
		where 
		ID = Vcls__id and Vcls__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.DOC_INF" doit exister à la création d'un enfant dans "INF.CLS_DOC_INF"
	if :new.DOC__ID is not null and seq = 0 then 
		open c1_cls_doc_inf ( :new.DOC__ID);
		fetch c1_cls_doc_inf into dummy;
		found := c1_cls_doc_inf%FOUND;
		close c1_cls_doc_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.DOC_INF". Impossible de modifier un enfant dans "INF.CLS_DOC_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CLS_INF" doit exister à la création d'un enfant dans "INF.CLS_DOC_INF"
	if :new.CLS__ID is not null and seq = 0 then 
		open c2_cls_doc_inf ( :new.CLS__ID);
		fetch c2_cls_doc_inf into dummy;
		found := c2_cls_doc_inf%FOUND;
		close c2_cls_doc_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CLS_INF". Impossible de modifier un enfant dans "INF.CLS_DOC_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_CDDECINF" before insert
on INF.CD_DEC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.FAM_DEC_INF"
	cursor c1_cd_dec_inf(Vfam_dec_inf__fam_dec varchar) is
		select 1 
		from INF.FAM_DEC_INF 
		where 
		FAM_DEC = Vfam_dec_inf__fam_dec and Vfam_dec_inf__fam_dec is not null;
begin

	
	--  Le parent "INF.FAM_DEC_INF" doit exister à la création d'un enfant dans "INF.CD_DEC_INF"
	if :new.FAM_DEC_INF__FAM_DEC is not null then 
		open c1_cd_dec_inf ( :new.FAM_DEC_INF__FAM_DEC);
		fetch c1_cd_dec_inf into dummy;
		found := c1_cd_dec_inf%FOUND;
		close c1_cd_dec_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.FAM_DEC_INF". Impossible de créer un enfant dans "INF.CD_DEC_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_CDDECINF" before update
on INF.CD_DEC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.FAM_DEC_INF"
	cursor c1_cd_dec_inf (Vfam_dec_inf__fam_dec varchar) is
		select 1 
		from INF.FAM_DEC_INF 
		where 
		FAM_DEC = Vfam_dec_inf__fam_dec and Vfam_dec_inf__fam_dec is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.FAM_DEC_INF" doit exister à la création d'un enfant dans "INF.CD_DEC_INF"
	if :new.FAM_DEC_INF__FAM_DEC is not null and seq = 0 then 
		open c1_cd_dec_inf ( :new.FAM_DEC_INF__FAM_DEC);
		fetch c1_cd_dec_inf into dummy;
		found := c1_cd_dec_inf%FOUND;
		close c1_cd_dec_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.FAM_DEC_INF". Impossible de modifier un enfant dans "INF.CD_DEC_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUA_CDDECINF" after update
of FAM_DEC_INF__FAM_DEC,CD_DEC
on INF.CD_DEC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_DEC_INF" dans les enfants "INF.TR_DEC_INF"
	if ((updating('FAM_DEC_INF__FAM_DEC') and :old.FAM_DEC_INF__FAM_DEC != :new.FAM_DEC_INF__FAM_DEC) or 
	(updating('CD_DEC') and :old.CD_DEC != :new.CD_DEC)) then 
		update INF.TR_DEC_INF
		set FAM_DEC_INF__FAM_DEC = :new.FAM_DEC_INF__FAM_DEC,
		CD_DEC_INF__CD_DEC = :new.CD_DEC  
		where FAM_DEC_INF__FAM_DEC = :old.FAM_DEC_INF__FAM_DEC and 
		CD_DEC_INF__CD_DEC = :old.CD_DEC;
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


create or replace TRIGGER "INF"."TDA_CDDECINF" after delete
on INF.CD_DEC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.TR_DEC_INF"
	delete INF.TR_DEC_INF
	where FAM_DEC_INF__FAM_DEC = :old.FAM_DEC_INF__FAM_DEC and 
	CD_DEC_INF__CD_DEC = :old.CD_DEC;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CDPOSITINF" after update
of POSIT
on INF.CD_POSIT_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_POSIT_INF" dans les enfants "INF.SECURITE_INF"
	if ((updating('POSIT') and :old.POSIT != :new.POSIT)) then 
		update INF.SECURITE_INF
		set CD_POSIT_INF__POSIT = :new.POSIT  
		where CD_POSIT_INF__POSIT = :old.POSIT;
	end if;
	--  Modification du code du parent "INF.CD_POSIT_INF" dans les enfants "INF.ECLAIRAGE_INF"
	if ((updating('POSIT') and :old.POSIT != :new.POSIT)) then 
		update INF.ECLAIRAGE_INF
		set CD_POSIT_INF__POSIT = :new.POSIT  
		where CD_POSIT_INF__POSIT = :old.POSIT;
	end if;
	--  Modification du code du parent "INF.CD_POSIT_INF" dans les enfants "INF.EVT_INF"
	if ((updating('POSIT') and :old.POSIT != :new.POSIT)) then 
		update INF.EVT_INF
		set CD_POSIT_INF__POSIT = :new.POSIT  
		where CD_POSIT_INF__POSIT = :old.POSIT;
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


create or replace TRIGGER "INF"."TDA_CDPOSITINF" after delete
on INF.CD_POSIT_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.SECURITE_INF"
	delete INF.SECURITE_INF
	where CD_POSIT_INF__POSIT = :old.POSIT;
	
	--  Suppression des enfants dans "INF.ECLAIRAGE_INF"
	delete INF.ECLAIRAGE_INF
	where CD_POSIT_INF__POSIT = :old.POSIT;
	
	--  Suppression des enfants dans "INF.EVT_INF"
	delete INF.EVT_INF
	where CD_POSIT_INF__POSIT = :old.POSIT;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CDVOIEINF" after update
of VOIE
on INF.CD_VOIE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_VOIE_INF" dans les enfants "INF.PAVE_VOIE_INF"
	if ((updating('VOIE') and :old.VOIE != :new.VOIE)) then 
		update INF.PAVE_VOIE_INF
		set CD_VOIE_INF__VOIE = :new.VOIE  
		where CD_VOIE_INF__VOIE = :old.VOIE;
	end if;
	--  Modification du code du parent "INF.CD_VOIE_INF" dans les enfants "INF.CL_VOIE_INF"
	if ((updating('VOIE') and :old.VOIE != :new.VOIE)) then 
		update INF.CL_VOIE_INF
		set CD_VOIE_INF__VOIE = :new.VOIE  
		where CD_VOIE_INF__VOIE = :old.VOIE;
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


create or replace TRIGGER "INF"."TDA_CDVOIEINF" after delete
on INF.CD_VOIE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.PAVE_VOIE_INF"
	delete INF.PAVE_VOIE_INF
	where CD_VOIE_INF__VOIE = :old.VOIE;
	
	--  Suppression des enfants dans "INF.CL_VOIE_INF"
	delete INF.CL_VOIE_INF
	where CD_VOIE_INF__VOIE = :old.VOIE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TIB_CONTACTINF" before insert
on INF.CONTACT_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.DOC_INF"
	cursor c1_contact_inf(Vdoc__id number) is
		select 1 
		from INF.DOC_INF 
		where 
		ID = Vdoc__id and Vdoc__id is not null;
begin

	
	--  Le parent "INF.DOC_INF" doit exister à la création d'un enfant dans "INF.CONTACT_INF"
	if :new.DOC__ID is not null then 
		open c1_contact_inf ( :new.DOC__ID);
		fetch c1_contact_inf into dummy;
		found := c1_contact_inf%FOUND;
		close c1_contact_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.DOC_INF". Impossible de créer un enfant dans "INF.CONTACT_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_CONTACTINF" before update
on INF.CONTACT_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.DOC_INF"
	cursor c1_contact_inf (Vdoc__id number) is
		select 1 
		from INF.DOC_INF 
		where 
		ID = Vdoc__id and Vdoc__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.DOC_INF" doit exister à la création d'un enfant dans "INF.CONTACT_INF"
	if :new.DOC__ID is not null and seq = 0 then 
		open c1_contact_inf ( :new.DOC__ID);
		fetch c1_contact_inf into dummy;
		found := c1_contact_inf%FOUND;
		close c1_contact_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.DOC_INF". Impossible de modifier un enfant dans "INF.CONTACT_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_CORRESPONDANCEINF" before insert
on INF.CORRESPONDANCE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_correspondance_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.CORRESPONDANCE_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c1_correspondance_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_correspondance_inf into dummy;
		found := c1_correspondance_inf%FOUND;
		close c1_correspondance_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.CORRESPONDANCE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_CORRESPONDANCEINF" before update
on INF.CORRESPONDANCE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_correspondance_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.CORRESPONDANCE_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c1_correspondance_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_correspondance_inf into dummy;
		found := c1_correspondance_inf%FOUND;
		close c1_correspondance_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.CORRESPONDANCE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_DOCINF" before insert
on INF.DOC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_DOC_INF"
	cursor c1_doc_inf(Vcd_doc__code varchar) is
		select 1 
		from INF.CD_DOC_INF 
		where 
		CODE = Vcd_doc__code and Vcd_doc__code is not null;
begin

	
	--  Le parent "INF.CD_DOC_INF" doit exister à la création d'un enfant dans "INF.DOC_INF"
	if :new.CD_DOC__CODE is not null then 
		open c1_doc_inf ( :new.CD_DOC__CODE);
		fetch c1_doc_inf into dummy;
		found := c1_doc_inf%FOUND;
		close c1_doc_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_DOC_INF". Impossible de créer un enfant dans "INF.DOC_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_DOCINF" before update
on INF.DOC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_DOC_INF"
	cursor c1_doc_inf (Vcd_doc__code varchar) is
		select 1 
		from INF.CD_DOC_INF 
		where 
		CODE = Vcd_doc__code and Vcd_doc__code is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CD_DOC_INF" doit exister à la création d'un enfant dans "INF.DOC_INF"
	if :new.CD_DOC__CODE is not null and seq = 0 then 
		open c1_doc_inf ( :new.CD_DOC__CODE);
		fetch c1_doc_inf into dummy;
		found := c1_doc_inf%FOUND;
		close c1_doc_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_DOC_INF". Impossible de modifier un enfant dans "INF.DOC_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUA_DOCINF" after update
of ID
on INF.DOC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.DOC_INF" dans les enfants "INF.CONTACT_INF"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update INF.CONTACT_INF
		set DOC__ID = :new.ID  
		where DOC__ID = :old.ID;
	end if;
	--  Modification du code du parent "INF.DOC_INF" dans les enfants "INF.CLS_DOC_INF"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update INF.CLS_DOC_INF
		set DOC__ID = :new.ID  
		where DOC__ID = :old.ID;
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


create or replace TRIGGER "INF"."TDA_DOCINF" after delete
on INF.DOC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.CONTACT_INF"
	delete INF.CONTACT_INF
	where DOC__ID = :old.ID;
	
	--  Suppression des enfants dans "INF.CLS_DOC_INF"
	delete INF.CLS_DOC_INF
	where DOC__ID = :old.ID;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TIB_ECLAIRAGEINF" before insert
on INF.ECLAIRAGE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_ECLAIR_INF"
	cursor c1_eclairage_inf(Vcd_eclair_inf__type varchar) is
		select 1 
		from INF.CD_ECLAIR_INF 
		where 
		TYPE = Vcd_eclair_inf__type and Vcd_eclair_inf__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_POSIT_INF"
	cursor c2_eclairage_inf(Vcd_posit_inf__posit varchar) is
		select 1 
		from INF.CD_POSIT_INF 
		where 
		POSIT = Vcd_posit_inf__posit and Vcd_posit_inf__posit is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c3_eclairage_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	
	--  Le parent "INF.CD_ECLAIR_INF" doit exister à la création d'un enfant dans "INF.ECLAIRAGE_INF"
	if :new.CD_ECLAIR_INF__TYPE is not null then 
		open c1_eclairage_inf ( :new.CD_ECLAIR_INF__TYPE);
		fetch c1_eclairage_inf into dummy;
		found := c1_eclairage_inf%FOUND;
		close c1_eclairage_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_ECLAIR_INF". Impossible de créer un enfant dans "INF.ECLAIRAGE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CD_POSIT_INF" doit exister à la création d'un enfant dans "INF.ECLAIRAGE_INF"
	if :new.CD_POSIT_INF__POSIT is not null then 
		open c2_eclairage_inf ( :new.CD_POSIT_INF__POSIT);
		fetch c2_eclairage_inf into dummy;
		found := c2_eclairage_inf%FOUND;
		close c2_eclairage_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_POSIT_INF". Impossible de créer un enfant dans "INF.ECLAIRAGE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.ECLAIRAGE_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c3_eclairage_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c3_eclairage_inf into dummy;
		found := c3_eclairage_inf%FOUND;
		close c3_eclairage_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.ECLAIRAGE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_ECLAIRAGEINF" before update
on INF.ECLAIRAGE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_ECLAIR_INF"
	cursor c1_eclairage_inf (Vcd_eclair_inf__type varchar) is
		select 1 
		from INF.CD_ECLAIR_INF 
		where 
		TYPE = Vcd_eclair_inf__type and Vcd_eclair_inf__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_POSIT_INF"
	cursor c2_eclairage_inf (Vcd_posit_inf__posit varchar) is
		select 1 
		from INF.CD_POSIT_INF 
		where 
		POSIT = Vcd_posit_inf__posit and Vcd_posit_inf__posit is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c3_eclairage_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CD_ECLAIR_INF" doit exister à la création d'un enfant dans "INF.ECLAIRAGE_INF"
	if :new.CD_ECLAIR_INF__TYPE is not null and seq = 0 then 
		open c1_eclairage_inf ( :new.CD_ECLAIR_INF__TYPE);
		fetch c1_eclairage_inf into dummy;
		found := c1_eclairage_inf%FOUND;
		close c1_eclairage_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_ECLAIR_INF". Impossible de modifier un enfant dans "INF.ECLAIRAGE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CD_POSIT_INF" doit exister à la création d'un enfant dans "INF.ECLAIRAGE_INF"
	if :new.CD_POSIT_INF__POSIT is not null and seq = 0 then 
		open c2_eclairage_inf ( :new.CD_POSIT_INF__POSIT);
		fetch c2_eclairage_inf into dummy;
		found := c2_eclairage_inf%FOUND;
		close c2_eclairage_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_POSIT_INF". Impossible de modifier un enfant dans "INF.ECLAIRAGE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.ECLAIRAGE_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c3_eclairage_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c3_eclairage_inf into dummy;
		found := c3_eclairage_inf%FOUND;
		close c3_eclairage_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.ECLAIRAGE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_EVTINF" before insert
on INF.EVT_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_EVT_INF"
	cursor c1_evt_inf(Vcd_evt_inf__type varchar) is
		select 1 
		from INF.CD_EVT_INF 
		where 
		TYPE = Vcd_evt_inf__type and Vcd_evt_inf__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_POSIT_INF"
	cursor c2_evt_inf(Vcd_posit_inf__posit varchar) is
		select 1 
		from INF.CD_POSIT_INF 
		where 
		POSIT = Vcd_posit_inf__posit and Vcd_posit_inf__posit is not null;
begin

	
	--  Le parent "INF.CD_EVT_INF" doit exister à la création d'un enfant dans "INF.EVT_INF"
	if :new.CD_EVT_INF__TYPE is not null then 
		open c1_evt_inf ( :new.CD_EVT_INF__TYPE);
		fetch c1_evt_inf into dummy;
		found := c1_evt_inf%FOUND;
		close c1_evt_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_EVT_INF". Impossible de créer un enfant dans "INF.EVT_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CD_POSIT_INF" doit exister à la création d'un enfant dans "INF.EVT_INF"
	if :new.CD_POSIT_INF__POSIT is not null then 
		open c2_evt_inf ( :new.CD_POSIT_INF__POSIT);
		fetch c2_evt_inf into dummy;
		found := c2_evt_inf%FOUND;
		close c2_evt_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_POSIT_INF". Impossible de créer un enfant dans "INF.EVT_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_EVTINF" before update
on INF.EVT_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_EVT_INF"
	cursor c1_evt_inf (Vcd_evt_inf__type varchar) is
		select 1 
		from INF.CD_EVT_INF 
		where 
		TYPE = Vcd_evt_inf__type and Vcd_evt_inf__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_POSIT_INF"
	cursor c2_evt_inf (Vcd_posit_inf__posit varchar) is
		select 1 
		from INF.CD_POSIT_INF 
		where 
		POSIT = Vcd_posit_inf__posit and Vcd_posit_inf__posit is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CD_EVT_INF" doit exister à la création d'un enfant dans "INF.EVT_INF"
	if :new.CD_EVT_INF__TYPE is not null and seq = 0 then 
		open c1_evt_inf ( :new.CD_EVT_INF__TYPE);
		fetch c1_evt_inf into dummy;
		found := c1_evt_inf%FOUND;
		close c1_evt_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_EVT_INF". Impossible de modifier un enfant dans "INF.EVT_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CD_POSIT_INF" doit exister à la création d'un enfant dans "INF.EVT_INF"
	if :new.CD_POSIT_INF__POSIT is not null and seq = 0 then 
		open c2_evt_inf ( :new.CD_POSIT_INF__POSIT);
		fetch c2_evt_inf into dummy;
		found := c2_evt_inf%FOUND;
		close c2_evt_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_POSIT_INF". Impossible de modifier un enfant dans "INF.EVT_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUA_FAMDECINF" after update
of FAM_DEC
on INF.FAM_DEC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.FAM_DEC_INF" dans les enfants "INF.CD_DEC_INF"
	if ((updating('FAM_DEC') and :old.FAM_DEC != :new.FAM_DEC)) then 
		update INF.CD_DEC_INF
		set FAM_DEC_INF__FAM_DEC = :new.FAM_DEC  
		where FAM_DEC_INF__FAM_DEC = :old.FAM_DEC;
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


create or replace TRIGGER "INF"."TDA_FAMDECINF" after delete
on INF.FAM_DEC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.CD_DEC_INF"
	delete INF.CD_DEC_INF
	where FAM_DEC_INF__FAM_DEC = :old.FAM_DEC;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TIB_GAREINF" before insert
on INF.GARE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_GARE_INF"
	cursor c1_gare_inf(Vcd_gare_inf__type varchar) is
		select 1 
		from INF.CD_GARE_INF 
		where 
		TYPE = Vcd_gare_inf__type and Vcd_gare_inf__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c2_gare_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	
	--  Le parent "INF.CD_GARE_INF" doit exister à la création d'un enfant dans "INF.GARE_INF"
	if :new.CD_GARE_INF__TYPE is not null then 
		open c1_gare_inf ( :new.CD_GARE_INF__TYPE);
		fetch c1_gare_inf into dummy;
		found := c1_gare_inf%FOUND;
		close c1_gare_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_GARE_INF". Impossible de créer un enfant dans "INF.GARE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.GARE_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c2_gare_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c2_gare_inf into dummy;
		found := c2_gare_inf%FOUND;
		close c2_gare_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.GARE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_GAREINF" before update
on INF.GARE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_GARE_INF"
	cursor c1_gare_inf (Vcd_gare_inf__type varchar) is
		select 1 
		from INF.CD_GARE_INF 
		where 
		TYPE = Vcd_gare_inf__type and Vcd_gare_inf__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c2_gare_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CD_GARE_INF" doit exister à la création d'un enfant dans "INF.GARE_INF"
	if :new.CD_GARE_INF__TYPE is not null and seq = 0 then 
		open c1_gare_inf ( :new.CD_GARE_INF__TYPE);
		fetch c1_gare_inf into dummy;
		found := c1_gare_inf%FOUND;
		close c1_gare_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_GARE_INF". Impossible de modifier un enfant dans "INF.GARE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.GARE_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c2_gare_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c2_gare_inf into dummy;
		found := c2_gare_inf%FOUND;
		close c2_gare_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.GARE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_LIAISONINF" before insert
on INF.LIAISON_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_LIAISON_INF"
	cursor c1_liaison_inf(Vcd_liaison_inf__cd_liaison varchar) is
		select 1 
		from INF.CD_LIAISON_INF 
		where 
		CD_LIAISON = Vcd_liaison_inf__cd_liaison and Vcd_liaison_inf__cd_liaison is not null;
begin

	
	--  Le parent "INF.CD_LIAISON_INF" doit exister à la création d'un enfant dans "INF.LIAISON_INF"
	if :new.CD_LIAISON_INF__CD_LIAISON is not null then 
		open c1_liaison_inf ( :new.CD_LIAISON_INF__CD_LIAISON);
		fetch c1_liaison_inf into dummy;
		found := c1_liaison_inf%FOUND;
		close c1_liaison_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_LIAISON_INF". Impossible de créer un enfant dans "INF.LIAISON_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_LIAISONINF" before update
on INF.LIAISON_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_LIAISON_INF"
	cursor c1_liaison_inf (Vcd_liaison_inf__cd_liaison varchar) is
		select 1 
		from INF.CD_LIAISON_INF 
		where 
		CD_LIAISON = Vcd_liaison_inf__cd_liaison and Vcd_liaison_inf__cd_liaison is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CD_LIAISON_INF" doit exister à la création d'un enfant dans "INF.LIAISON_INF"
	if :new.CD_LIAISON_INF__CD_LIAISON is not null and seq = 0 then 
		open c1_liaison_inf ( :new.CD_LIAISON_INF__CD_LIAISON);
		fetch c1_liaison_inf into dummy;
		found := c1_liaison_inf%FOUND;
		close c1_liaison_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_LIAISON_INF". Impossible de modifier un enfant dans "INF.LIAISON_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUA_LIAISONINF" after update
of LIAISON
on INF.LIAISON_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.LIAISON_INF" dans les enfants "INF.CHAUSSEE_INF"
	if ((updating('LIAISON') and :old.LIAISON != :new.LIAISON)) then 
		update INF.CHAUSSEE_INF
		set LIAISON_INF__LIAISON = :new.LIAISON  
		where LIAISON_INF__LIAISON = :old.LIAISON;
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


create or replace TRIGGER "INF"."TDA_LIAISONINF" after delete
on INF.LIAISON_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.CHAUSSEE_INF"
	delete INF.CHAUSSEE_INF
	where LIAISON_INF__LIAISON = :old.LIAISON;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TIB_OCCUPATIONINF" before insert
on INF.OCCUPATION_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_OCCUP_INF"
	cursor c1_occupation_inf(Vcd_occup_inf__type varchar) is
		select 1 
		from INF.CD_OCCUP_INF 
		where 
		TYPE = Vcd_occup_inf__type and Vcd_occup_inf__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_OCCUPANT_INF"
	cursor c2_occupation_inf(Vcd_occupant_inf__nom varchar) is
		select 1 
		from INF.CD_OCCUPANT_INF 
		where 
		NOM = Vcd_occupant_inf__nom and Vcd_occupant_inf__nom is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c3_occupation_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	
	--  Le parent "INF.CD_OCCUP_INF" doit exister à la création d'un enfant dans "INF.OCCUPATION_INF"
	if :new.CD_OCCUP_INF__TYPE is not null then 
		open c1_occupation_inf ( :new.CD_OCCUP_INF__TYPE);
		fetch c1_occupation_inf into dummy;
		found := c1_occupation_inf%FOUND;
		close c1_occupation_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_OCCUP_INF". Impossible de créer un enfant dans "INF.OCCUPATION_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CD_OCCUPANT_INF" doit exister à la création d'un enfant dans "INF.OCCUPATION_INF"
	if :new.CD_OCCUPANT_INF__NOM is not null then 
		open c2_occupation_inf ( :new.CD_OCCUPANT_INF__NOM);
		fetch c2_occupation_inf into dummy;
		found := c2_occupation_inf%FOUND;
		close c2_occupation_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_OCCUPANT_INF". Impossible de créer un enfant dans "INF.OCCUPATION_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.OCCUPATION_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c3_occupation_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c3_occupation_inf into dummy;
		found := c3_occupation_inf%FOUND;
		close c3_occupation_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.OCCUPATION_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_OCCUPATIONINF" before update
on INF.OCCUPATION_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_OCCUP_INF"
	cursor c1_occupation_inf (Vcd_occup_inf__type varchar) is
		select 1 
		from INF.CD_OCCUP_INF 
		where 
		TYPE = Vcd_occup_inf__type and Vcd_occup_inf__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_OCCUPANT_INF"
	cursor c2_occupation_inf (Vcd_occupant_inf__nom varchar) is
		select 1 
		from INF.CD_OCCUPANT_INF 
		where 
		NOM = Vcd_occupant_inf__nom and Vcd_occupant_inf__nom is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c3_occupation_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CD_OCCUP_INF" doit exister à la création d'un enfant dans "INF.OCCUPATION_INF"
	if :new.CD_OCCUP_INF__TYPE is not null and seq = 0 then 
		open c1_occupation_inf ( :new.CD_OCCUP_INF__TYPE);
		fetch c1_occupation_inf into dummy;
		found := c1_occupation_inf%FOUND;
		close c1_occupation_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_OCCUP_INF". Impossible de modifier un enfant dans "INF.OCCUPATION_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CD_OCCUPANT_INF" doit exister à la création d'un enfant dans "INF.OCCUPATION_INF"
	if :new.CD_OCCUPANT_INF__NOM is not null and seq = 0 then 
		open c2_occupation_inf ( :new.CD_OCCUPANT_INF__NOM);
		fetch c2_occupation_inf into dummy;
		found := c2_occupation_inf%FOUND;
		close c2_occupation_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_OCCUPANT_INF". Impossible de modifier un enfant dans "INF.OCCUPATION_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.OCCUPATION_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c3_occupation_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c3_occupation_inf into dummy;
		found := c3_occupation_inf%FOUND;
		close c3_occupation_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.OCCUPATION_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_PAVEVOIEINF" before insert
on INF.PAVE_VOIE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_VOIE_INF"
	cursor c1_pave_voie_inf(Vcd_voie_inf__voie varchar) is
		select 1 
		from INF.CD_VOIE_INF 
		where 
		VOIE = Vcd_voie_inf__voie and Vcd_voie_inf__voie is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c2_pave_voie_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	
	--  Le parent "INF.CD_VOIE_INF" doit exister à la création d'un enfant dans "INF.PAVE_VOIE_INF"
	if :new.CD_VOIE_INF__VOIE is not null then 
		open c1_pave_voie_inf ( :new.CD_VOIE_INF__VOIE);
		fetch c1_pave_voie_inf into dummy;
		found := c1_pave_voie_inf%FOUND;
		close c1_pave_voie_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_VOIE_INF". Impossible de créer un enfant dans "INF.PAVE_VOIE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.PAVE_VOIE_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c2_pave_voie_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c2_pave_voie_inf into dummy;
		found := c2_pave_voie_inf%FOUND;
		close c2_pave_voie_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.PAVE_VOIE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_PAVEVOIEINF" before update
on INF.PAVE_VOIE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_VOIE_INF"
	cursor c1_pave_voie_inf (Vcd_voie_inf__voie varchar) is
		select 1 
		from INF.CD_VOIE_INF 
		where 
		VOIE = Vcd_voie_inf__voie and Vcd_voie_inf__voie is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c2_pave_voie_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CD_VOIE_INF" doit exister à la création d'un enfant dans "INF.PAVE_VOIE_INF"
	if :new.CD_VOIE_INF__VOIE is not null and seq = 0 then 
		open c1_pave_voie_inf ( :new.CD_VOIE_INF__VOIE);
		fetch c1_pave_voie_inf into dummy;
		found := c1_pave_voie_inf%FOUND;
		close c1_pave_voie_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_VOIE_INF". Impossible de modifier un enfant dans "INF.PAVE_VOIE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.PAVE_VOIE_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c2_pave_voie_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c2_pave_voie_inf into dummy;
		found := c2_pave_voie_inf%FOUND;
		close c2_pave_voie_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.PAVE_VOIE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_PKINF" before insert
on INF.PK_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_pk_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.PK_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c1_pk_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_pk_inf into dummy;
		found := c1_pk_inf%FOUND;
		close c1_pk_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.PK_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_PKINF" before update
on INF.PK_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_pk_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.PK_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c1_pk_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_pk_inf into dummy;
		found := c1_pk_inf%FOUND;
		close c1_pk_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.PK_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_AIREPLACEINF" before insert
on INF.AIRE__PLACE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_PLACE_INF"
	cursor c1_aire__place_inf(Vcd_place_inf__parking varchar) is
		select 1 
		from INF.CD_PLACE_INF 
		where 
		PARKING = Vcd_place_inf__parking and Vcd_place_inf__parking is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.AIRE_INF"
	cursor c2_aire__place_inf(Vliaison_inf__liaison varchar,
	Vcd_aire_inf__type varchar,
	Vchaussee_inf__sens varchar,
	Vaire_inf__abs_deb number) is
		select 1 
		from INF.AIRE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		CD_AIRE_INF__TYPE = Vcd_aire_inf__type and Vcd_aire_inf__type is not null and 
		CHAUSSEE_INF__SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null and 
		ABS_DEB = Vaire_inf__abs_deb and Vaire_inf__abs_deb is not null;
begin

	
	--  Le parent "INF.CD_PLACE_INF" doit exister à la création d'un enfant dans "INF.AIRE__PLACE_INF"
	if :new.CD_PLACE_INF__PARKING is not null then 
		open c1_aire__place_inf ( :new.CD_PLACE_INF__PARKING);
		fetch c1_aire__place_inf into dummy;
		found := c1_aire__place_inf%FOUND;
		close c1_aire__place_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_PLACE_INF". Impossible de créer un enfant dans "INF.AIRE__PLACE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.AIRE_INF" doit exister à la création d'un enfant dans "INF.AIRE__PLACE_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CD_AIRE_INF__TYPE is not null and 
	:new.CHAUSSEE_INF__SENS is not null and 
	:new.AIRE_INF__ABS_DEB is not null then 
		open c2_aire__place_inf ( :new.LIAISON_INF__LIAISON,
		:new.CD_AIRE_INF__TYPE,
		:new.CHAUSSEE_INF__SENS,
		:new.AIRE_INF__ABS_DEB);
		fetch c2_aire__place_inf into dummy;
		found := c2_aire__place_inf%FOUND;
		close c2_aire__place_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.AIRE_INF". Impossible de créer un enfant dans "INF.AIRE__PLACE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_AIREPLACEINF" before update
on INF.AIRE__PLACE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_PLACE_INF"
	cursor c1_aire__place_inf (Vcd_place_inf__parking varchar) is
		select 1 
		from INF.CD_PLACE_INF 
		where 
		PARKING = Vcd_place_inf__parking and Vcd_place_inf__parking is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.AIRE_INF"
	cursor c2_aire__place_inf (Vliaison_inf__liaison varchar,
	Vcd_aire_inf__type varchar,
	Vchaussee_inf__sens varchar,
	Vaire_inf__abs_deb number) is
		select 1 
		from INF.AIRE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		CD_AIRE_INF__TYPE = Vcd_aire_inf__type and Vcd_aire_inf__type is not null and 
		CHAUSSEE_INF__SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null and 
		ABS_DEB = Vaire_inf__abs_deb and Vaire_inf__abs_deb is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CD_PLACE_INF" doit exister à la création d'un enfant dans "INF.AIRE__PLACE_INF"
	if :new.CD_PLACE_INF__PARKING is not null and seq = 0 then 
		open c1_aire__place_inf ( :new.CD_PLACE_INF__PARKING);
		fetch c1_aire__place_inf into dummy;
		found := c1_aire__place_inf%FOUND;
		close c1_aire__place_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_PLACE_INF". Impossible de modifier un enfant dans "INF.AIRE__PLACE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.AIRE_INF" doit exister à la création d'un enfant dans "INF.AIRE__PLACE_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CD_AIRE_INF__TYPE is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 and 
	:new.AIRE_INF__ABS_DEB is not null and seq = 0 then 
		open c2_aire__place_inf ( :new.LIAISON_INF__LIAISON,
		:new.CD_AIRE_INF__TYPE,
		:new.CHAUSSEE_INF__SENS,
		:new.AIRE_INF__ABS_DEB);
		fetch c2_aire__place_inf into dummy;
		found := c2_aire__place_inf%FOUND;
		close c2_aire__place_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.AIRE_INF". Impossible de modifier un enfant dans "INF.AIRE__PLACE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_PTSINGINF" before insert
on INF.PT_SING_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_pt_sing_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_PT_SING_INF"
	cursor c2_pt_sing_inf(Vcd_pt_sing_inf__code varchar) is
		select 1 
		from INF.CD_PT_SING_INF 
		where 
		CODE = Vcd_pt_sing_inf__code and Vcd_pt_sing_inf__code is not null;
begin

	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.PT_SING_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c1_pt_sing_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_pt_sing_inf into dummy;
		found := c1_pt_sing_inf%FOUND;
		close c1_pt_sing_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.PT_SING_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CD_PT_SING_INF" doit exister à la création d'un enfant dans "INF.PT_SING_INF"
	if :new.CD_PT_SING_INF__CODE is not null then 
		open c2_pt_sing_inf ( :new.CD_PT_SING_INF__CODE);
		fetch c2_pt_sing_inf into dummy;
		found := c2_pt_sing_inf%FOUND;
		close c2_pt_sing_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_PT_SING_INF". Impossible de créer un enfant dans "INF.PT_SING_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_PTSINGINF" before update
on INF.PT_SING_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_pt_sing_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_PT_SING_INF"
	cursor c2_pt_sing_inf (Vcd_pt_sing_inf__code varchar) is
		select 1 
		from INF.CD_PT_SING_INF 
		where 
		CODE = Vcd_pt_sing_inf__code and Vcd_pt_sing_inf__code is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.PT_SING_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c1_pt_sing_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_pt_sing_inf into dummy;
		found := c1_pt_sing_inf%FOUND;
		close c1_pt_sing_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.PT_SING_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CD_PT_SING_INF" doit exister à la création d'un enfant dans "INF.PT_SING_INF"
	if :new.CD_PT_SING_INF__CODE is not null and seq = 0 then 
		open c2_pt_sing_inf ( :new.CD_PT_SING_INF__CODE);
		fetch c2_pt_sing_inf into dummy;
		found := c2_pt_sing_inf%FOUND;
		close c2_pt_sing_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_PT_SING_INF". Impossible de modifier un enfant dans "INF.PT_SING_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_REPEREINF" before insert
on INF.REPERE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_repere_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.REPERE_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c1_repere_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_repere_inf into dummy;
		found := c1_repere_inf%FOUND;
		close c1_repere_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.REPERE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_REPEREINF" before update
on INF.REPERE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_repere_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.REPERE_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c1_repere_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_repere_inf into dummy;
		found := c1_repere_inf%FOUND;
		close c1_repere_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.REPERE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_PRESTATAIREINF" before insert
on INF.PRESTATAIRE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_PRESTATAIRE_INF"
	cursor c1_prestataire_inf(Vcd_prestataire_inf__type varchar) is
		select 1 
		from INF.CD_PRESTATAIRE_INF 
		where 
		TYPE = Vcd_prestataire_inf__type and Vcd_prestataire_inf__type is not null;
begin

	
	--  Le parent "INF.CD_PRESTATAIRE_INF" doit exister à la création d'un enfant dans "INF.PRESTATAIRE_INF"
	if :new.CD_PRESTATAIRE_INF__TYPE is not null then 
		open c1_prestataire_inf ( :new.CD_PRESTATAIRE_INF__TYPE);
		fetch c1_prestataire_inf into dummy;
		found := c1_prestataire_inf%FOUND;
		close c1_prestataire_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_PRESTATAIRE_INF". Impossible de créer un enfant dans "INF.PRESTATAIRE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_PRESTATAIREINF" before update
on INF.PRESTATAIRE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_PRESTATAIRE_INF"
	cursor c1_prestataire_inf (Vcd_prestataire_inf__type varchar) is
		select 1 
		from INF.CD_PRESTATAIRE_INF 
		where 
		TYPE = Vcd_prestataire_inf__type and Vcd_prestataire_inf__type is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CD_PRESTATAIRE_INF" doit exister à la création d'un enfant dans "INF.PRESTATAIRE_INF"
	if :new.CD_PRESTATAIRE_INF__TYPE is not null and seq = 0 then 
		open c1_prestataire_inf ( :new.CD_PRESTATAIRE_INF__TYPE);
		fetch c1_prestataire_inf into dummy;
		found := c1_prestataire_inf%FOUND;
		close c1_prestataire_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_PRESTATAIRE_INF". Impossible de modifier un enfant dans "INF.PRESTATAIRE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUA_PRESTATAIREINF" after update
of CD_PRESTATAIRE_INF__TYPE,NOM
on INF.PRESTATAIRE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.PRESTATAIRE_INF" dans les enfants "INF.AIRE__PRESTATAIRE_INF"
	if ((updating('CD_PRESTATAIRE_INF__TYPE') and :old.CD_PRESTATAIRE_INF__TYPE != :new.CD_PRESTATAIRE_INF__TYPE) or 
	(updating('NOM') and :old.NOM != :new.NOM)) then 
		update INF.AIRE__PRESTATAIRE_INF
		set CD_PRESTATAIRE_INF__TYPE = :new.CD_PRESTATAIRE_INF__TYPE,
		PRESTATAIRE_INF__NOM = :new.NOM  
		where CD_PRESTATAIRE_INF__TYPE = :old.CD_PRESTATAIRE_INF__TYPE and 
		PRESTATAIRE_INF__NOM = :old.NOM;
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


create or replace TRIGGER "INF"."TDA_PRESTATAIREINF" after delete
on INF.PRESTATAIRE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.AIRE__PRESTATAIRE_INF"
	delete INF.AIRE__PRESTATAIRE_INF
	where CD_PRESTATAIRE_INF__TYPE = :old.CD_PRESTATAIRE_INF__TYPE and 
	PRESTATAIRE_INF__NOM = :old.NOM;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TIB_AIREPRESTATAIREINF" before insert
on INF.AIRE__PRESTATAIRE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.AIRE_INF"
	cursor c1_aire__prestataire_inf(Vliaison_inf__liaison varchar,
	Vcd_aire_inf__type varchar,
	Vchaussee_inf__sens varchar,
	Vaire_inf__abs_deb number) is
		select 1 
		from INF.AIRE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		CD_AIRE_INF__TYPE = Vcd_aire_inf__type and Vcd_aire_inf__type is not null and 
		CHAUSSEE_INF__SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null and 
		ABS_DEB = Vaire_inf__abs_deb and Vaire_inf__abs_deb is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.PRESTATAIRE_INF"
	cursor c2_aire__prestataire_inf(Vcd_prestataire_inf__type varchar,
	Vprestataire_inf__nom varchar) is
		select 1 
		from INF.PRESTATAIRE_INF 
		where 
		CD_PRESTATAIRE_INF__TYPE = Vcd_prestataire_inf__type and Vcd_prestataire_inf__type is not null and 
		NOM = Vprestataire_inf__nom and Vprestataire_inf__nom is not null;
begin

	
	--  Le parent "INF.AIRE_INF" doit exister à la création d'un enfant dans "INF.AIRE__PRESTATAIRE_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CD_AIRE_INF__TYPE is not null and 
	:new.CHAUSSEE_INF__SENS is not null and 
	:new.AIRE_INF__ABS_DEB is not null then 
		open c1_aire__prestataire_inf ( :new.LIAISON_INF__LIAISON,
		:new.CD_AIRE_INF__TYPE,
		:new.CHAUSSEE_INF__SENS,
		:new.AIRE_INF__ABS_DEB);
		fetch c1_aire__prestataire_inf into dummy;
		found := c1_aire__prestataire_inf%FOUND;
		close c1_aire__prestataire_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.AIRE_INF". Impossible de créer un enfant dans "INF.AIRE__PRESTATAIRE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.PRESTATAIRE_INF" doit exister à la création d'un enfant dans "INF.AIRE__PRESTATAIRE_INF"
	if :new.CD_PRESTATAIRE_INF__TYPE is not null and 
	:new.PRESTATAIRE_INF__NOM is not null then 
		open c2_aire__prestataire_inf ( :new.CD_PRESTATAIRE_INF__TYPE,
		:new.PRESTATAIRE_INF__NOM);
		fetch c2_aire__prestataire_inf into dummy;
		found := c2_aire__prestataire_inf%FOUND;
		close c2_aire__prestataire_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.PRESTATAIRE_INF". Impossible de créer un enfant dans "INF.AIRE__PRESTATAIRE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_AIREPRESTATAIREINF" before update
on INF.AIRE__PRESTATAIRE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.AIRE_INF"
	cursor c1_aire__prestataire_inf (Vliaison_inf__liaison varchar,
	Vcd_aire_inf__type varchar,
	Vchaussee_inf__sens varchar,
	Vaire_inf__abs_deb number) is
		select 1 
		from INF.AIRE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		CD_AIRE_INF__TYPE = Vcd_aire_inf__type and Vcd_aire_inf__type is not null and 
		CHAUSSEE_INF__SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null and 
		ABS_DEB = Vaire_inf__abs_deb and Vaire_inf__abs_deb is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.PRESTATAIRE_INF"
	cursor c2_aire__prestataire_inf (Vcd_prestataire_inf__type varchar,
	Vprestataire_inf__nom varchar) is
		select 1 
		from INF.PRESTATAIRE_INF 
		where 
		CD_PRESTATAIRE_INF__TYPE = Vcd_prestataire_inf__type and Vcd_prestataire_inf__type is not null and 
		NOM = Vprestataire_inf__nom and Vprestataire_inf__nom is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.AIRE_INF" doit exister à la création d'un enfant dans "INF.AIRE__PRESTATAIRE_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CD_AIRE_INF__TYPE is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 and 
	:new.AIRE_INF__ABS_DEB is not null and seq = 0 then 
		open c1_aire__prestataire_inf ( :new.LIAISON_INF__LIAISON,
		:new.CD_AIRE_INF__TYPE,
		:new.CHAUSSEE_INF__SENS,
		:new.AIRE_INF__ABS_DEB);
		fetch c1_aire__prestataire_inf into dummy;
		found := c1_aire__prestataire_inf%FOUND;
		close c1_aire__prestataire_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.AIRE_INF". Impossible de modifier un enfant dans "INF.AIRE__PRESTATAIRE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.PRESTATAIRE_INF" doit exister à la création d'un enfant dans "INF.AIRE__PRESTATAIRE_INF"
	if :new.CD_PRESTATAIRE_INF__TYPE is not null and seq = 0 and 
	:new.PRESTATAIRE_INF__NOM is not null and seq = 0 then 
		open c2_aire__prestataire_inf ( :new.CD_PRESTATAIRE_INF__TYPE,
		:new.PRESTATAIRE_INF__NOM);
		fetch c2_aire__prestataire_inf into dummy;
		found := c2_aire__prestataire_inf%FOUND;
		close c2_aire__prestataire_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.PRESTATAIRE_INF". Impossible de modifier un enfant dans "INF.AIRE__PRESTATAIRE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_PREVSGEINF" before insert
on INF.PREV_SGE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_prev_sge_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.PREV_SGE_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c1_prev_sge_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_prev_sge_inf into dummy;
		found := c1_prev_sge_inf%FOUND;
		close c1_prev_sge_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.PREV_SGE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_PREVSGEINF" before update
on INF.PREV_SGE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_prev_sge_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.PREV_SGE_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c1_prev_sge_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_prev_sge_inf into dummy;
		found := c1_prev_sge_inf%FOUND;
		close c1_prev_sge_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.PREV_SGE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_AMENAGEMENTINF" before insert
on INF.AMENAGEMENT_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_AMENAG_INF"
	cursor c1_amenagement_inf(Vcd_amenag_inf__type_amenag varchar) is
		select 1 
		from INF.CD_AMENAG_INF 
		where 
		TYPE_AMENAG = Vcd_amenag_inf__type_amenag and Vcd_amenag_inf__type_amenag is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c2_amenagement_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	
	--  Le parent "INF.CD_AMENAG_INF" doit exister à la création d'un enfant dans "INF.AMENAGEMENT_INF"
	if :new.CD_AMENAG_INF__TYPE_AMENAG is not null then 
		open c1_amenagement_inf ( :new.CD_AMENAG_INF__TYPE_AMENAG);
		fetch c1_amenagement_inf into dummy;
		found := c1_amenagement_inf%FOUND;
		close c1_amenagement_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_AMENAG_INF". Impossible de créer un enfant dans "INF.AMENAGEMENT_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.AMENAGEMENT_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c2_amenagement_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c2_amenagement_inf into dummy;
		found := c2_amenagement_inf%FOUND;
		close c2_amenagement_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.AMENAGEMENT_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_AMENAGEMENTINF" before update
on INF.AMENAGEMENT_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_AMENAG_INF"
	cursor c1_amenagement_inf (Vcd_amenag_inf__type_amenag varchar) is
		select 1 
		from INF.CD_AMENAG_INF 
		where 
		TYPE_AMENAG = Vcd_amenag_inf__type_amenag and Vcd_amenag_inf__type_amenag is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c2_amenagement_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CD_AMENAG_INF" doit exister à la création d'un enfant dans "INF.AMENAGEMENT_INF"
	if :new.CD_AMENAG_INF__TYPE_AMENAG is not null and seq = 0 then 
		open c1_amenagement_inf ( :new.CD_AMENAG_INF__TYPE_AMENAG);
		fetch c1_amenagement_inf into dummy;
		found := c1_amenagement_inf%FOUND;
		close c1_amenagement_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_AMENAG_INF". Impossible de modifier un enfant dans "INF.AMENAGEMENT_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.AMENAGEMENT_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c2_amenagement_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c2_amenagement_inf into dummy;
		found := c2_amenagement_inf%FOUND;
		close c2_amenagement_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.AMENAGEMENT_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_REPARTITIONTRAFICINF" before insert
on INF.REPARTITION_TRAFIC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_repartition_trafic_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.REPARTITION_TRAFIC_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c1_repartition_trafic_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_repartition_trafic_inf into dummy;
		found := c1_repartition_trafic_inf%FOUND;
		close c1_repartition_trafic_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.REPARTITION_TRAFIC_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_REPARTITIONTRAFICINF" before update
on INF.REPARTITION_TRAFIC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_repartition_trafic_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.REPARTITION_TRAFIC_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c1_repartition_trafic_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_repartition_trafic_inf into dummy;
		found := c1_repartition_trafic_inf%FOUND;
		close c1_repartition_trafic_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.REPARTITION_TRAFIC_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_SECTIONTRAFICINF" before insert
on INF.SECTION_TRAFIC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_section_trafic_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_CLASS_TRAF_INF"
	cursor c2_section_trafic_inf(Vcd_class_traf_inf__code varchar) is
		select 1 
		from INF.CD_CLASS_TRAF_INF 
		where 
		CODE = Vcd_class_traf_inf__code and Vcd_class_traf_inf__code is not null;
begin

	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.SECTION_TRAFIC_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c1_section_trafic_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_section_trafic_inf into dummy;
		found := c1_section_trafic_inf%FOUND;
		close c1_section_trafic_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.SECTION_TRAFIC_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CD_CLASS_TRAF_INF" doit exister à la création d'un enfant dans "INF.SECTION_TRAFIC_INF"
	if :new.CD_CLASS_TRAF_INF__CODE is not null then 
		open c2_section_trafic_inf ( :new.CD_CLASS_TRAF_INF__CODE);
		fetch c2_section_trafic_inf into dummy;
		found := c2_section_trafic_inf%FOUND;
		close c2_section_trafic_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_CLASS_TRAF_INF". Impossible de créer un enfant dans "INF.SECTION_TRAFIC_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_SECTIONTRAFICINF" before update
on INF.SECTION_TRAFIC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_section_trafic_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_CLASS_TRAF_INF"
	cursor c2_section_trafic_inf (Vcd_class_traf_inf__code varchar) is
		select 1 
		from INF.CD_CLASS_TRAF_INF 
		where 
		CODE = Vcd_class_traf_inf__code and Vcd_class_traf_inf__code is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.SECTION_TRAFIC_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c1_section_trafic_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_section_trafic_inf into dummy;
		found := c1_section_trafic_inf%FOUND;
		close c1_section_trafic_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.SECTION_TRAFIC_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CD_CLASS_TRAF_INF" doit exister à la création d'un enfant dans "INF.SECTION_TRAFIC_INF"
	if :new.CD_CLASS_TRAF_INF__CODE is not null and seq = 0 then 
		open c2_section_trafic_inf ( :new.CD_CLASS_TRAF_INF__CODE);
		fetch c2_section_trafic_inf into dummy;
		found := c2_section_trafic_inf%FOUND;
		close c2_section_trafic_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_CLASS_TRAF_INF". Impossible de modifier un enfant dans "INF.SECTION_TRAFIC_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_SECURITEINF" before insert
on INF.SECURITE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_securite_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_SECUR_INF"
	cursor c2_securite_inf(Vcd_secur_inf__type varchar) is
		select 1 
		from INF.CD_SECUR_INF 
		where 
		TYPE = Vcd_secur_inf__type and Vcd_secur_inf__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_POSIT_INF"
	cursor c3_securite_inf(Vcd_posit_inf__posit varchar) is
		select 1 
		from INF.CD_POSIT_INF 
		where 
		POSIT = Vcd_posit_inf__posit and Vcd_posit_inf__posit is not null;
begin

	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.SECURITE_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c1_securite_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_securite_inf into dummy;
		found := c1_securite_inf%FOUND;
		close c1_securite_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.SECURITE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CD_SECUR_INF" doit exister à la création d'un enfant dans "INF.SECURITE_INF"
	if :new.CD_SECUR_INF__TYPE is not null then 
		open c2_securite_inf ( :new.CD_SECUR_INF__TYPE);
		fetch c2_securite_inf into dummy;
		found := c2_securite_inf%FOUND;
		close c2_securite_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_SECUR_INF". Impossible de créer un enfant dans "INF.SECURITE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CD_POSIT_INF" doit exister à la création d'un enfant dans "INF.SECURITE_INF"
	if :new.CD_POSIT_INF__POSIT is not null then 
		open c3_securite_inf ( :new.CD_POSIT_INF__POSIT);
		fetch c3_securite_inf into dummy;
		found := c3_securite_inf%FOUND;
		close c3_securite_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_POSIT_INF". Impossible de créer un enfant dans "INF.SECURITE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_SECURITEINF" before update
on INF.SECURITE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_securite_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_SECUR_INF"
	cursor c2_securite_inf (Vcd_secur_inf__type varchar) is
		select 1 
		from INF.CD_SECUR_INF 
		where 
		TYPE = Vcd_secur_inf__type and Vcd_secur_inf__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_POSIT_INF"
	cursor c3_securite_inf (Vcd_posit_inf__posit varchar) is
		select 1 
		from INF.CD_POSIT_INF 
		where 
		POSIT = Vcd_posit_inf__posit and Vcd_posit_inf__posit is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.SECURITE_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c1_securite_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_securite_inf into dummy;
		found := c1_securite_inf%FOUND;
		close c1_securite_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.SECURITE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CD_SECUR_INF" doit exister à la création d'un enfant dans "INF.SECURITE_INF"
	if :new.CD_SECUR_INF__TYPE is not null and seq = 0 then 
		open c2_securite_inf ( :new.CD_SECUR_INF__TYPE);
		fetch c2_securite_inf into dummy;
		found := c2_securite_inf%FOUND;
		close c2_securite_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_SECUR_INF". Impossible de modifier un enfant dans "INF.SECURITE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CD_POSIT_INF" doit exister à la création d'un enfant dans "INF.SECURITE_INF"
	if :new.CD_POSIT_INF__POSIT is not null and seq = 0 then 
		open c3_securite_inf ( :new.CD_POSIT_INF__POSIT);
		fetch c3_securite_inf into dummy;
		found := c3_securite_inf%FOUND;
		close c3_securite_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_POSIT_INF". Impossible de modifier un enfant dans "INF.SECURITE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_AIRESERVICEINF" before insert
on INF.AIRE__SERVICE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_SERVICE_INF"
	cursor c1_aire__service_inf(Vcd_service_inf__service varchar) is
		select 1 
		from INF.CD_SERVICE_INF 
		where 
		SERVICE = Vcd_service_inf__service and Vcd_service_inf__service is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.AIRE_INF"
	cursor c2_aire__service_inf(Vliaison_inf__liaison varchar,
	Vcd_aire_inf__type varchar,
	Vchaussee_inf__sens varchar,
	Vaire_inf__abs_deb number) is
		select 1 
		from INF.AIRE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		CD_AIRE_INF__TYPE = Vcd_aire_inf__type and Vcd_aire_inf__type is not null and 
		CHAUSSEE_INF__SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null and 
		ABS_DEB = Vaire_inf__abs_deb and Vaire_inf__abs_deb is not null;
begin

	
	--  Le parent "INF.CD_SERVICE_INF" doit exister à la création d'un enfant dans "INF.AIRE__SERVICE_INF"
	if :new.CD_SERVICE_INF__SERVICE is not null then 
		open c1_aire__service_inf ( :new.CD_SERVICE_INF__SERVICE);
		fetch c1_aire__service_inf into dummy;
		found := c1_aire__service_inf%FOUND;
		close c1_aire__service_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_SERVICE_INF". Impossible de créer un enfant dans "INF.AIRE__SERVICE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.AIRE_INF" doit exister à la création d'un enfant dans "INF.AIRE__SERVICE_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CD_AIRE_INF__TYPE is not null and 
	:new.CHAUSSEE_INF__SENS is not null and 
	:new.AIRE_INF__ABS_DEB is not null then 
		open c2_aire__service_inf ( :new.LIAISON_INF__LIAISON,
		:new.CD_AIRE_INF__TYPE,
		:new.CHAUSSEE_INF__SENS,
		:new.AIRE_INF__ABS_DEB);
		fetch c2_aire__service_inf into dummy;
		found := c2_aire__service_inf%FOUND;
		close c2_aire__service_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.AIRE_INF". Impossible de créer un enfant dans "INF.AIRE__SERVICE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_AIRESERVICEINF" before update
on INF.AIRE__SERVICE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_SERVICE_INF"
	cursor c1_aire__service_inf (Vcd_service_inf__service varchar) is
		select 1 
		from INF.CD_SERVICE_INF 
		where 
		SERVICE = Vcd_service_inf__service and Vcd_service_inf__service is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.AIRE_INF"
	cursor c2_aire__service_inf (Vliaison_inf__liaison varchar,
	Vcd_aire_inf__type varchar,
	Vchaussee_inf__sens varchar,
	Vaire_inf__abs_deb number) is
		select 1 
		from INF.AIRE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		CD_AIRE_INF__TYPE = Vcd_aire_inf__type and Vcd_aire_inf__type is not null and 
		CHAUSSEE_INF__SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null and 
		ABS_DEB = Vaire_inf__abs_deb and Vaire_inf__abs_deb is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CD_SERVICE_INF" doit exister à la création d'un enfant dans "INF.AIRE__SERVICE_INF"
	if :new.CD_SERVICE_INF__SERVICE is not null and seq = 0 then 
		open c1_aire__service_inf ( :new.CD_SERVICE_INF__SERVICE);
		fetch c1_aire__service_inf into dummy;
		found := c1_aire__service_inf%FOUND;
		close c1_aire__service_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_SERVICE_INF". Impossible de modifier un enfant dans "INF.AIRE__SERVICE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.AIRE_INF" doit exister à la création d'un enfant dans "INF.AIRE__SERVICE_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CD_AIRE_INF__TYPE is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 and 
	:new.AIRE_INF__ABS_DEB is not null and seq = 0 then 
		open c2_aire__service_inf ( :new.LIAISON_INF__LIAISON,
		:new.CD_AIRE_INF__TYPE,
		:new.CHAUSSEE_INF__SENS,
		:new.AIRE_INF__ABS_DEB);
		fetch c2_aire__service_inf into dummy;
		found := c2_aire__service_inf%FOUND;
		close c2_aire__service_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.AIRE_INF". Impossible de modifier un enfant dans "INF.AIRE__SERVICE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_TALUSINF" before insert
on INF.TALUS_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_TALUS_INF"
	cursor c1_talus_inf(Vcd_talus_inf__type varchar) is
		select 1 
		from INF.CD_TALUS_INF 
		where 
		TYPE = Vcd_talus_inf__type and Vcd_talus_inf__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c2_talus_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	
	--  Le parent "INF.CD_TALUS_INF" doit exister à la création d'un enfant dans "INF.TALUS_INF"
	if :new.CD_TALUS_INF__TYPE is not null then 
		open c1_talus_inf ( :new.CD_TALUS_INF__TYPE);
		fetch c1_talus_inf into dummy;
		found := c1_talus_inf%FOUND;
		close c1_talus_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_TALUS_INF". Impossible de créer un enfant dans "INF.TALUS_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.TALUS_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c2_talus_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c2_talus_inf into dummy;
		found := c2_talus_inf%FOUND;
		close c2_talus_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.TALUS_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_TALUSINF" before update
on INF.TALUS_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_TALUS_INF"
	cursor c1_talus_inf (Vcd_talus_inf__type varchar) is
		select 1 
		from INF.CD_TALUS_INF 
		where 
		TYPE = Vcd_talus_inf__type and Vcd_talus_inf__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c2_talus_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CD_TALUS_INF" doit exister à la création d'un enfant dans "INF.TALUS_INF"
	if :new.CD_TALUS_INF__TYPE is not null and seq = 0 then 
		open c1_talus_inf ( :new.CD_TALUS_INF__TYPE);
		fetch c1_talus_inf into dummy;
		found := c1_talus_inf%FOUND;
		close c1_talus_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_TALUS_INF". Impossible de modifier un enfant dans "INF.TALUS_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.TALUS_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c2_talus_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c2_talus_inf into dummy;
		found := c2_talus_inf%FOUND;
		close c2_talus_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.TALUS_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_TPCINF" before insert
on INF.TPC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_TPC_INF"
	cursor c1_tpc_inf(Vcd_tpc_inf__code varchar) is
		select 1 
		from INF.CD_TPC_INF 
		where 
		CODE = Vcd_tpc_inf__code and Vcd_tpc_inf__code is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c2_tpc_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	
	--  Le parent "INF.CD_TPC_INF" doit exister à la création d'un enfant dans "INF.TPC_INF"
	if :new.CD_TPC_INF__CODE is not null then 
		open c1_tpc_inf ( :new.CD_TPC_INF__CODE);
		fetch c1_tpc_inf into dummy;
		found := c1_tpc_inf%FOUND;
		close c1_tpc_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_TPC_INF". Impossible de créer un enfant dans "INF.TPC_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.TPC_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c2_tpc_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c2_tpc_inf into dummy;
		found := c2_tpc_inf%FOUND;
		close c2_tpc_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.TPC_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_TPCINF" before update
on INF.TPC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_TPC_INF"
	cursor c1_tpc_inf (Vcd_tpc_inf__code varchar) is
		select 1 
		from INF.CD_TPC_INF 
		where 
		CODE = Vcd_tpc_inf__code and Vcd_tpc_inf__code is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c2_tpc_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CD_TPC_INF" doit exister à la création d'un enfant dans "INF.TPC_INF"
	if :new.CD_TPC_INF__CODE is not null and seq = 0 then 
		open c1_tpc_inf ( :new.CD_TPC_INF__CODE);
		fetch c1_tpc_inf into dummy;
		found := c1_tpc_inf%FOUND;
		close c1_tpc_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_TPC_INF". Impossible de modifier un enfant dans "INF.TPC_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.TPC_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c2_tpc_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c2_tpc_inf into dummy;
		found := c2_tpc_inf%FOUND;
		close c2_tpc_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.TPC_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_TRAFICINF" before insert
on INF.TRAFIC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_trafic_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.TRAFIC_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c1_trafic_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_trafic_inf into dummy;
		found := c1_trafic_inf%FOUND;
		close c1_trafic_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.TRAFIC_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_TRAFICINF" before update
on INF.TRAFIC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_trafic_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.TRAFIC_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c1_trafic_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_trafic_inf into dummy;
		found := c1_trafic_inf%FOUND;
		close c1_trafic_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.TRAFIC_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_TRDECINF" before insert
on INF.TR_DEC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_tr_dec_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_DEC_INF"
	cursor c2_tr_dec_inf(Vfam_dec_inf__fam_dec varchar,
	Vcd_dec_inf__cd_dec varchar) is
		select 1 
		from INF.CD_DEC_INF 
		where 
		FAM_DEC_INF__FAM_DEC = Vfam_dec_inf__fam_dec and Vfam_dec_inf__fam_dec is not null and 
		CD_DEC = Vcd_dec_inf__cd_dec and Vcd_dec_inf__cd_dec is not null;
begin

	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.TR_DEC_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c1_tr_dec_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_tr_dec_inf into dummy;
		found := c1_tr_dec_inf%FOUND;
		close c1_tr_dec_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.TR_DEC_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CD_DEC_INF" doit exister à la création d'un enfant dans "INF.TR_DEC_INF"
	if :new.FAM_DEC_INF__FAM_DEC is not null and 
	:new.CD_DEC_INF__CD_DEC is not null then 
		open c2_tr_dec_inf ( :new.FAM_DEC_INF__FAM_DEC,
		:new.CD_DEC_INF__CD_DEC);
		fetch c2_tr_dec_inf into dummy;
		found := c2_tr_dec_inf%FOUND;
		close c2_tr_dec_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_DEC_INF". Impossible de créer un enfant dans "INF.TR_DEC_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_TRDECINF" before update
on INF.TR_DEC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c1_tr_dec_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_DEC_INF"
	cursor c2_tr_dec_inf (Vfam_dec_inf__fam_dec varchar,
	Vcd_dec_inf__cd_dec varchar) is
		select 1 
		from INF.CD_DEC_INF 
		where 
		FAM_DEC_INF__FAM_DEC = Vfam_dec_inf__fam_dec and Vfam_dec_inf__fam_dec is not null and 
		CD_DEC = Vcd_dec_inf__cd_dec and Vcd_dec_inf__cd_dec is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.TR_DEC_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c1_tr_dec_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c1_tr_dec_inf into dummy;
		found := c1_tr_dec_inf%FOUND;
		close c1_tr_dec_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.TR_DEC_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CD_DEC_INF" doit exister à la création d'un enfant dans "INF.TR_DEC_INF"
	if :new.FAM_DEC_INF__FAM_DEC is not null and seq = 0 and 
	:new.CD_DEC_INF__CD_DEC is not null and seq = 0 then 
		open c2_tr_dec_inf ( :new.FAM_DEC_INF__FAM_DEC,
		:new.CD_DEC_INF__CD_DEC);
		fetch c2_tr_dec_inf into dummy;
		found := c2_tr_dec_inf%FOUND;
		close c2_tr_dec_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_DEC_INF". Impossible de modifier un enfant dans "INF.TR_DEC_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUA_CDAIREINF" after update
of TYPE
on INF.CD_AIRE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_AIRE_INF" dans les enfants "INF.AIRE_INF"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update INF.AIRE_INF
		set CD_AIRE_INF__TYPE = :new.TYPE  
		where CD_AIRE_INF__TYPE = :old.TYPE;
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


create or replace TRIGGER "INF"."TDA_CDAIREINF" after delete
on INF.CD_AIRE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.AIRE_INF"
	delete INF.AIRE_INF
	where CD_AIRE_INF__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CDAMENAGINF" after update
of TYPE_AMENAG
on INF.CD_AMENAG_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_AMENAG_INF" dans les enfants "INF.AMENAGEMENT_INF"
	if ((updating('TYPE_AMENAG') and :old.TYPE_AMENAG != :new.TYPE_AMENAG)) then 
		update INF.AMENAGEMENT_INF
		set CD_AMENAG_INF__TYPE_AMENAG = :new.TYPE_AMENAG  
		where CD_AMENAG_INF__TYPE_AMENAG = :old.TYPE_AMENAG;
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


create or replace TRIGGER "INF"."TDA_CDAMENAGINF" after delete
on INF.CD_AMENAG_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.AMENAGEMENT_INF"
	delete INF.AMENAGEMENT_INF
	where CD_AMENAG_INF__TYPE_AMENAG = :old.TYPE_AMENAG;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CDBIFINF" after update
of TYPE
on INF.CD_BIF_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_BIF_INF" dans les enfants "INF.BIFURCATION_INF"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update INF.BIFURCATION_INF
		set CD_BIF_INF__TYPE = :new.TYPE  
		where CD_BIF_INF__TYPE = :old.TYPE;
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


create or replace TRIGGER "INF"."TDA_CDBIFINF" after delete
on INF.CD_BIF_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.BIFURCATION_INF"
	delete INF.BIFURCATION_INF
	where CD_BIF_INF__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CDDOCINF" after update
of CODE
on INF.CD_DOC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_DOC_INF" dans les enfants "INF.DOC_INF"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update INF.DOC_INF
		set CD_DOC__CODE = :new.CODE  
		where CD_DOC__CODE = :old.CODE;
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


create or replace TRIGGER "INF"."TDA_CDDOCINF" after delete
on INF.CD_DOC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.DOC_INF"
	delete INF.DOC_INF
	where CD_DOC__CODE = :old.CODE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CDEVTINF" after update
of TYPE
on INF.CD_EVT_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_EVT_INF" dans les enfants "INF.EVT_INF"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update INF.EVT_INF
		set CD_EVT_INF__TYPE = :new.TYPE  
		where CD_EVT_INF__TYPE = :old.TYPE;
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


create or replace TRIGGER "INF"."TDA_CDEVTINF" after delete
on INF.CD_EVT_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.EVT_INF"
	delete INF.EVT_INF
	where CD_EVT_INF__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CDECLAIRINF" after update
of TYPE
on INF.CD_ECLAIR_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_ECLAIR_INF" dans les enfants "INF.ECLAIRAGE_INF"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update INF.ECLAIRAGE_INF
		set CD_ECLAIR_INF__TYPE = :new.TYPE  
		where CD_ECLAIR_INF__TYPE = :old.TYPE;
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


create or replace TRIGGER "INF"."TDA_CDECLAIRINF" after delete
on INF.CD_ECLAIR_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.ECLAIRAGE_INF"
	delete INF.ECLAIRAGE_INF
	where CD_ECLAIR_INF__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CDGAREINF" after update
of TYPE
on INF.CD_GARE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_GARE_INF" dans les enfants "INF.GARE_INF"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update INF.GARE_INF
		set CD_GARE_INF__TYPE = :new.TYPE  
		where CD_GARE_INF__TYPE = :old.TYPE;
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


create or replace TRIGGER "INF"."TDA_CDGAREINF" after delete
on INF.CD_GARE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.GARE_INF"
	delete INF.GARE_INF
	where CD_GARE_INF__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CDLIAISONINF" after update
of CD_LIAISON
on INF.CD_LIAISON_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_LIAISON_INF" dans les enfants "INF.LIAISON_INF"
	if ((updating('CD_LIAISON') and :old.CD_LIAISON != :new.CD_LIAISON)) then 
		update INF.LIAISON_INF
		set CD_LIAISON_INF__CD_LIAISON = :new.CD_LIAISON  
		where CD_LIAISON_INF__CD_LIAISON = :old.CD_LIAISON;
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


create or replace TRIGGER "INF"."TDA_CDLIAISONINF" after delete
on INF.CD_LIAISON_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.LIAISON_INF"
	delete INF.LIAISON_INF
	where CD_LIAISON_INF__CD_LIAISON = :old.CD_LIAISON;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CDOCCUPANTINF" after update
of NOM
on INF.CD_OCCUPANT_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_OCCUPANT_INF" dans les enfants "INF.OCCUPATION_INF"
	if ((updating('NOM') and :old.NOM != :new.NOM)) then 
		update INF.OCCUPATION_INF
		set CD_OCCUPANT_INF__NOM = :new.NOM  
		where CD_OCCUPANT_INF__NOM = :old.NOM;
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


create or replace TRIGGER "INF"."TDA_CDOCCUPANTINF" after delete
on INF.CD_OCCUPANT_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.OCCUPATION_INF"
	delete INF.OCCUPATION_INF
	where CD_OCCUPANT_INF__NOM = :old.NOM;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CDOCCUPINF" after update
of TYPE
on INF.CD_OCCUP_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_OCCUP_INF" dans les enfants "INF.OCCUPATION_INF"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update INF.OCCUPATION_INF
		set CD_OCCUP_INF__TYPE = :new.TYPE  
		where CD_OCCUP_INF__TYPE = :old.TYPE;
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


create or replace TRIGGER "INF"."TDA_CDOCCUPINF" after delete
on INF.CD_OCCUP_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.OCCUPATION_INF"
	delete INF.OCCUPATION_INF
	where CD_OCCUP_INF__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CDPLACEINF" after update
of PARKING
on INF.CD_PLACE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_PLACE_INF" dans les enfants "INF.AIRE__PLACE_INF"
	if ((updating('PARKING') and :old.PARKING != :new.PARKING)) then 
		update INF.AIRE__PLACE_INF
		set CD_PLACE_INF__PARKING = :new.PARKING  
		where CD_PLACE_INF__PARKING = :old.PARKING;
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


create or replace TRIGGER "INF"."TDA_CDPLACEINF" after delete
on INF.CD_PLACE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.AIRE__PLACE_INF"
	delete INF.AIRE__PLACE_INF
	where CD_PLACE_INF__PARKING = :old.PARKING;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CDPTSINGINF" after update
of CODE
on INF.CD_PT_SING_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_PT_SING_INF" dans les enfants "INF.PT_SING_INF"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update INF.PT_SING_INF
		set CD_PT_SING_INF__CODE = :new.CODE  
		where CD_PT_SING_INF__CODE = :old.CODE;
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


create or replace TRIGGER "INF"."TDA_CDPTSINGINF" after delete
on INF.CD_PT_SING_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.PT_SING_INF"
	delete INF.PT_SING_INF
	where CD_PT_SING_INF__CODE = :old.CODE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CDPRESTATAIREINF" after update
of TYPE
on INF.CD_PRESTATAIRE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_PRESTATAIRE_INF" dans les enfants "INF.PRESTATAIRE_INF"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update INF.PRESTATAIRE_INF
		set CD_PRESTATAIRE_INF__TYPE = :new.TYPE  
		where CD_PRESTATAIRE_INF__TYPE = :old.TYPE;
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


create or replace TRIGGER "INF"."TDA_CDPRESTATAIREINF" after delete
on INF.CD_PRESTATAIRE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.PRESTATAIRE_INF"
	delete INF.PRESTATAIRE_INF
	where CD_PRESTATAIRE_INF__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CDSECURINF" after update
of TYPE
on INF.CD_SECUR_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_SECUR_INF" dans les enfants "INF.SECURITE_INF"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update INF.SECURITE_INF
		set CD_SECUR_INF__TYPE = :new.TYPE  
		where CD_SECUR_INF__TYPE = :old.TYPE;
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


create or replace TRIGGER "INF"."TDA_CDSECURINF" after delete
on INF.CD_SECUR_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.SECURITE_INF"
	delete INF.SECURITE_INF
	where CD_SECUR_INF__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CDSERVICEINF" after update
of SERVICE
on INF.CD_SERVICE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_SERVICE_INF" dans les enfants "INF.AIRE__SERVICE_INF"
	if ((updating('SERVICE') and :old.SERVICE != :new.SERVICE)) then 
		update INF.AIRE__SERVICE_INF
		set CD_SERVICE_INF__SERVICE = :new.SERVICE  
		where CD_SERVICE_INF__SERVICE = :old.SERVICE;
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


create or replace TRIGGER "INF"."TDA_CDSERVICEINF" after delete
on INF.CD_SERVICE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.AIRE__SERVICE_INF"
	delete INF.AIRE__SERVICE_INF
	where CD_SERVICE_INF__SERVICE = :old.SERVICE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CDTALUSINF" after update
of TYPE
on INF.CD_TALUS_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_TALUS_INF" dans les enfants "INF.TALUS_INF"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update INF.TALUS_INF
		set CD_TALUS_INF__TYPE = :new.TYPE  
		where CD_TALUS_INF__TYPE = :old.TYPE;
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


create or replace TRIGGER "INF"."TDA_CDTALUSINF" after delete
on INF.CD_TALUS_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.TALUS_INF"
	delete INF.TALUS_INF
	where CD_TALUS_INF__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CDTPCINF" after update
of CODE
on INF.CD_TPC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_TPC_INF" dans les enfants "INF.TPC_INF"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update INF.TPC_INF
		set CD_TPC_INF__CODE = :new.CODE  
		where CD_TPC_INF__CODE = :old.CODE;
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


create or replace TRIGGER "INF"."TDA_CDTPCINF" after delete
on INF.CD_TPC_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.TPC_INF"
	delete INF.TPC_INF
	where CD_TPC_INF__CODE = :old.CODE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CDCLIMINF" after update
of CODE
on INF.CD_CLIM_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_CLIM_INF" dans les enfants "INF.CLIM_INF"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update INF.CLIM_INF
		set CD_CLIM_INF__CODE = :new.CODE  
		where CD_CLIM_INF__CODE = :old.CODE;
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


create or replace TRIGGER "INF"."TDA_CDCLIMINF" after delete
on INF.CD_CLIM_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.CLIM_INF"
	delete INF.CLIM_INF
	where CD_CLIM_INF__CODE = :old.CODE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TUA_CDSENSIBLEINF" after update
of CODE
on INF.CD_SENSIBLE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "INF.CD_SENSIBLE_INF" dans les enfants "INF.SENSIBLE_INF"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update INF.SENSIBLE_INF
		set CD_SENSIBLE_INF__CODE = :new.CODE  
		where CD_SENSIBLE_INF__CODE = :old.CODE;
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


create or replace TRIGGER "INF"."TDA_CDSENSIBLEINF" after delete
on INF.CD_SENSIBLE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "INF.SENSIBLE_INF"
	delete INF.SENSIBLE_INF
	where CD_SENSIBLE_INF__CODE = :old.CODE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "INF"."TIB_CLVOIEINF" before insert
on INF.CL_VOIE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_VOIE_INF"
	cursor c1_cl_voie_inf(Vcd_voie_inf__voie varchar) is
		select 1 
		from INF.CD_VOIE_INF 
		where 
		VOIE = Vcd_voie_inf__voie and Vcd_voie_inf__voie is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c2_cl_voie_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	
	--  Le parent "INF.CD_VOIE_INF" doit exister à la création d'un enfant dans "INF.CL_VOIE_INF"
	if :new.CD_VOIE_INF__VOIE is not null then 
		open c1_cl_voie_inf ( :new.CD_VOIE_INF__VOIE);
		fetch c1_cl_voie_inf into dummy;
		found := c1_cl_voie_inf%FOUND;
		close c1_cl_voie_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_VOIE_INF". Impossible de créer un enfant dans "INF.CL_VOIE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.CL_VOIE_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c2_cl_voie_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c2_cl_voie_inf into dummy;
		found := c2_cl_voie_inf%FOUND;
		close c2_cl_voie_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.CL_VOIE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_CLVOIEINF" before update
on INF.CL_VOIE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_VOIE_INF"
	cursor c1_cl_voie_inf (Vcd_voie_inf__voie varchar) is
		select 1 
		from INF.CD_VOIE_INF 
		where 
		VOIE = Vcd_voie_inf__voie and Vcd_voie_inf__voie is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c2_cl_voie_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CD_VOIE_INF" doit exister à la création d'un enfant dans "INF.CL_VOIE_INF"
	if :new.CD_VOIE_INF__VOIE is not null and seq = 0 then 
		open c1_cl_voie_inf ( :new.CD_VOIE_INF__VOIE);
		fetch c1_cl_voie_inf into dummy;
		found := c1_cl_voie_inf%FOUND;
		close c1_cl_voie_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_VOIE_INF". Impossible de modifier un enfant dans "INF.CL_VOIE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.CL_VOIE_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c2_cl_voie_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c2_cl_voie_inf into dummy;
		found := c2_cl_voie_inf%FOUND;
		close c2_cl_voie_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.CL_VOIE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TIB_SENSIBLEINF" before insert
on INF.SENSIBLE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CD_SENSIBLE_INF"
	cursor c1_sensible_inf(Vcd_sensible_inf__code varchar) is
		select 1 
		from INF.CD_SENSIBLE_INF 
		where 
		CODE = Vcd_sensible_inf__code and Vcd_sensible_inf__code is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c2_sensible_inf(Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	
	--  Le parent "INF.CD_SENSIBLE_INF" doit exister à la création d'un enfant dans "INF.SENSIBLE_INF"
	if :new.CD_SENSIBLE_INF__CODE is not null then 
		open c1_sensible_inf ( :new.CD_SENSIBLE_INF__CODE);
		fetch c1_sensible_inf into dummy;
		found := c1_sensible_inf%FOUND;
		close c1_sensible_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_SENSIBLE_INF". Impossible de créer un enfant dans "INF.SENSIBLE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.SENSIBLE_INF"
	if :new.LIAISON_INF__LIAISON is not null and 
	:new.CHAUSSEE_INF__SENS is not null then 
		open c2_sensible_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c2_sensible_inf into dummy;
		found := c2_sensible_inf%FOUND;
		close c2_sensible_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de créer un enfant dans "INF.SENSIBLE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "INF"."TUB_SENSIBLEINF" before update
on INF.SENSIBLE_INF for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CD_SENSIBLE_INF"
	cursor c1_sensible_inf (Vcd_sensible_inf__code varchar) is
		select 1 
		from INF.CD_SENSIBLE_INF 
		where 
		CODE = Vcd_sensible_inf__code and Vcd_sensible_inf__code is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "INF.CHAUSSEE_INF"
	cursor c2_sensible_inf (Vliaison_inf__liaison varchar,
	Vchaussee_inf__sens varchar) is
		select 1 
		from INF.CHAUSSEE_INF 
		where 
		LIAISON_INF__LIAISON = Vliaison_inf__liaison and Vliaison_inf__liaison is not null and 
		SENS = Vchaussee_inf__sens and Vchaussee_inf__sens is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "INF.CD_SENSIBLE_INF" doit exister à la création d'un enfant dans "INF.SENSIBLE_INF"
	if :new.CD_SENSIBLE_INF__CODE is not null and seq = 0 then 
		open c1_sensible_inf ( :new.CD_SENSIBLE_INF__CODE);
		fetch c1_sensible_inf into dummy;
		found := c1_sensible_inf%FOUND;
		close c1_sensible_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CD_SENSIBLE_INF". Impossible de modifier un enfant dans "INF.SENSIBLE_INF".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "INF.CHAUSSEE_INF" doit exister à la création d'un enfant dans "INF.SENSIBLE_INF"
	if :new.LIAISON_INF__LIAISON is not null and seq = 0 and 
	:new.CHAUSSEE_INF__SENS is not null and seq = 0 then 
		open c2_sensible_inf ( :new.LIAISON_INF__LIAISON,
		:new.CHAUSSEE_INF__SENS);
		fetch c2_sensible_inf into dummy;
		found := c2_sensible_inf%FOUND;
		close c2_sensible_inf;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "INF.CHAUSSEE_INF". Impossible de modifier un enfant dans "INF.SENSIBLE_INF".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


