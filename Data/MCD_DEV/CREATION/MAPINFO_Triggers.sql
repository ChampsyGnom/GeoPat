/*################################################################################################*/
/* Script     : MAPINFO_Triggers.sql                                                              */
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


create or replace TRIGGER "MAPINFO"."TIB_TBMAP" before insert
on MAPINFO.TB_MAP for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "MAPINFO.TB_GROUPE"
	cursor c1_tb_map(Vtb_modele__modele varchar,
	Vtb_template__tpl varchar,
	Vtb_groupe__groupe varchar) is
		select 1 
		from MAPINFO.TB_GROUPE 
		where 
		TB_MODELE__MODELE = Vtb_modele__modele and Vtb_modele__modele is not null and 
		TB_TEMPLATE__TPL = Vtb_template__tpl and Vtb_template__tpl is not null and 
		GROUPE = Vtb_groupe__groupe and Vtb_groupe__groupe is not null;
begin

	
	--  Le parent "MAPINFO.TB_GROUPE" doit exister à la création d'un enfant dans "MAPINFO.TB_MAP"
	if :new.TB_MODELE__MODELE is not null and 
	:new.TB_TEMPLATE__TPL is not null and 
	:new.TB_GROUPE__GROUPE is not null then 
		open c1_tb_map ( :new.TB_MODELE__MODELE,
		:new.TB_TEMPLATE__TPL,
		:new.TB_GROUPE__GROUPE);
		fetch c1_tb_map into dummy;
		found := c1_tb_map%FOUND;
		close c1_tb_map;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.TB_GROUPE". Impossible de créer un enfant dans "MAPINFO.TB_MAP".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TUB_TBMAP" before update
on MAPINFO.TB_MAP for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "MAPINFO.TB_GROUPE"
	cursor c1_tb_map (Vtb_modele__modele varchar,
	Vtb_template__tpl varchar,
	Vtb_groupe__groupe varchar) is
		select 1 
		from MAPINFO.TB_GROUPE 
		where 
		TB_MODELE__MODELE = Vtb_modele__modele and Vtb_modele__modele is not null and 
		TB_TEMPLATE__TPL = Vtb_template__tpl and Vtb_template__tpl is not null and 
		GROUPE = Vtb_groupe__groupe and Vtb_groupe__groupe is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "MAPINFO.TB_GROUPE" doit exister à la création d'un enfant dans "MAPINFO.TB_MAP"
	if :new.TB_MODELE__MODELE is not null and seq = 0 and 
	:new.TB_TEMPLATE__TPL is not null and seq = 0 and 
	:new.TB_GROUPE__GROUPE is not null and seq = 0 then 
		open c1_tb_map ( :new.TB_MODELE__MODELE,
		:new.TB_TEMPLATE__TPL,
		:new.TB_GROUPE__GROUPE);
		fetch c1_tb_map into dummy;
		found := c1_tb_map%FOUND;
		close c1_tb_map;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.TB_GROUPE". Impossible de modifier un enfant dans "MAPINFO.TB_MAP".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TUA_TBMAP" after update
of TB_MODELE__MODELE,TB_TEMPLATE__TPL,TB_GROUPE__GROUPE,MAP
on MAPINFO.TB_MAP for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "MAPINFO.TB_MAP" dans les enfants "MAPINFO.TB_MAP_CFG"
	if ((updating('TB_MODELE__MODELE') and :old.TB_MODELE__MODELE != :new.TB_MODELE__MODELE) or 
	(updating('TB_TEMPLATE__TPL') and :old.TB_TEMPLATE__TPL != :new.TB_TEMPLATE__TPL) or 
	(updating('TB_GROUPE__GROUPE') and :old.TB_GROUPE__GROUPE != :new.TB_GROUPE__GROUPE) or 
	(updating('MAP') and :old.MAP != :new.MAP)) then 
		update MAPINFO.TB_MAP_CFG
		set TB_MODELE__MODELE = :new.TB_MODELE__MODELE,
		TB_TEMPLATE__TPL = :new.TB_TEMPLATE__TPL,
		TB_GROUPE__GROUPE = :new.TB_GROUPE__GROUPE,
		TB_MAP__MAP = :new.MAP  
		where TB_MODELE__MODELE = :old.TB_MODELE__MODELE and 
		TB_TEMPLATE__TPL = :old.TB_TEMPLATE__TPL and 
		TB_GROUPE__GROUPE = :old.TB_GROUPE__GROUPE and 
		TB_MAP__MAP = :old.MAP;
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


create or replace TRIGGER "MAPINFO"."TDA_TBMAP" after delete
on MAPINFO.TB_MAP for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "MAPINFO.TB_MAP_CFG"
	delete MAPINFO.TB_MAP_CFG
	where TB_MODELE__MODELE = :old.TB_MODELE__MODELE and 
	TB_TEMPLATE__TPL = :old.TB_TEMPLATE__TPL and 
	TB_GROUPE__GROUPE = :old.TB_GROUPE__GROUPE and 
	TB_MAP__MAP = :old.MAP;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "MAPINFO"."TIB_TBMAPCFG" before insert
on MAPINFO.TB_MAP_CFG for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "MAPINFO.TB_MAP"
	cursor c1_tb_map_cfg(Vtb_modele__modele varchar,
	Vtb_template__tpl varchar,
	Vtb_groupe__groupe varchar,
	Vtb_map__map varchar) is
		select 1 
		from MAPINFO.TB_MAP 
		where 
		TB_MODELE__MODELE = Vtb_modele__modele and Vtb_modele__modele is not null and 
		TB_TEMPLATE__TPL = Vtb_template__tpl and Vtb_template__tpl is not null and 
		TB_GROUPE__GROUPE = Vtb_groupe__groupe and Vtb_groupe__groupe is not null and 
		MAP = Vtb_map__map and Vtb_map__map is not null;
begin

	
	--  Le parent "MAPINFO.TB_MAP" doit exister à la création d'un enfant dans "MAPINFO.TB_MAP_CFG"
	if :new.TB_MODELE__MODELE is not null and 
	:new.TB_TEMPLATE__TPL is not null and 
	:new.TB_GROUPE__GROUPE is not null and 
	:new.TB_MAP__MAP is not null then 
		open c1_tb_map_cfg ( :new.TB_MODELE__MODELE,
		:new.TB_TEMPLATE__TPL,
		:new.TB_GROUPE__GROUPE,
		:new.TB_MAP__MAP);
		fetch c1_tb_map_cfg into dummy;
		found := c1_tb_map_cfg%FOUND;
		close c1_tb_map_cfg;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.TB_MAP". Impossible de créer un enfant dans "MAPINFO.TB_MAP_CFG".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TUB_TBMAPCFG" before update
on MAPINFO.TB_MAP_CFG for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "MAPINFO.TB_MAP"
	cursor c1_tb_map_cfg (Vtb_modele__modele varchar,
	Vtb_template__tpl varchar,
	Vtb_groupe__groupe varchar,
	Vtb_map__map varchar) is
		select 1 
		from MAPINFO.TB_MAP 
		where 
		TB_MODELE__MODELE = Vtb_modele__modele and Vtb_modele__modele is not null and 
		TB_TEMPLATE__TPL = Vtb_template__tpl and Vtb_template__tpl is not null and 
		TB_GROUPE__GROUPE = Vtb_groupe__groupe and Vtb_groupe__groupe is not null and 
		MAP = Vtb_map__map and Vtb_map__map is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "MAPINFO.TB_MAP" doit exister à la création d'un enfant dans "MAPINFO.TB_MAP_CFG"
	if :new.TB_MODELE__MODELE is not null and seq = 0 and 
	:new.TB_TEMPLATE__TPL is not null and seq = 0 and 
	:new.TB_GROUPE__GROUPE is not null and seq = 0 and 
	:new.TB_MAP__MAP is not null and seq = 0 then 
		open c1_tb_map_cfg ( :new.TB_MODELE__MODELE,
		:new.TB_TEMPLATE__TPL,
		:new.TB_GROUPE__GROUPE,
		:new.TB_MAP__MAP);
		fetch c1_tb_map_cfg into dummy;
		found := c1_tb_map_cfg%FOUND;
		close c1_tb_map_cfg;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.TB_MAP". Impossible de modifier un enfant dans "MAPINFO.TB_MAP_CFG".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TIB_TBGROUPECFG" before insert
on MAPINFO.TB_GROUPE_CFG for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "MAPINFO.TB_GROUPE"
	cursor c1_tb_groupe_cfg(Vtb_modele__modele varchar,
	Vtb_template__tpl varchar,
	Vtb_groupe__groupe varchar) is
		select 1 
		from MAPINFO.TB_GROUPE 
		where 
		TB_MODELE__MODELE = Vtb_modele__modele and Vtb_modele__modele is not null and 
		TB_TEMPLATE__TPL = Vtb_template__tpl and Vtb_template__tpl is not null and 
		GROUPE = Vtb_groupe__groupe and Vtb_groupe__groupe is not null;
begin

	
	--  Le parent "MAPINFO.TB_GROUPE" doit exister à la création d'un enfant dans "MAPINFO.TB_GROUPE_CFG"
	if :new.TB_MODELE__MODELE is not null and 
	:new.TB_TEMPLATE__TPL is not null and 
	:new.TB_GROUPE__GROUPE is not null then 
		open c1_tb_groupe_cfg ( :new.TB_MODELE__MODELE,
		:new.TB_TEMPLATE__TPL,
		:new.TB_GROUPE__GROUPE);
		fetch c1_tb_groupe_cfg into dummy;
		found := c1_tb_groupe_cfg%FOUND;
		close c1_tb_groupe_cfg;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.TB_GROUPE". Impossible de créer un enfant dans "MAPINFO.TB_GROUPE_CFG".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TUB_TBGROUPECFG" before update
on MAPINFO.TB_GROUPE_CFG for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "MAPINFO.TB_GROUPE"
	cursor c1_tb_groupe_cfg (Vtb_modele__modele varchar,
	Vtb_template__tpl varchar,
	Vtb_groupe__groupe varchar) is
		select 1 
		from MAPINFO.TB_GROUPE 
		where 
		TB_MODELE__MODELE = Vtb_modele__modele and Vtb_modele__modele is not null and 
		TB_TEMPLATE__TPL = Vtb_template__tpl and Vtb_template__tpl is not null and 
		GROUPE = Vtb_groupe__groupe and Vtb_groupe__groupe is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "MAPINFO.TB_GROUPE" doit exister à la création d'un enfant dans "MAPINFO.TB_GROUPE_CFG"
	if :new.TB_MODELE__MODELE is not null and seq = 0 and 
	:new.TB_TEMPLATE__TPL is not null and seq = 0 and 
	:new.TB_GROUPE__GROUPE is not null and seq = 0 then 
		open c1_tb_groupe_cfg ( :new.TB_MODELE__MODELE,
		:new.TB_TEMPLATE__TPL,
		:new.TB_GROUPE__GROUPE);
		fetch c1_tb_groupe_cfg into dummy;
		found := c1_tb_groupe_cfg%FOUND;
		close c1_tb_groupe_cfg;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.TB_GROUPE". Impossible de modifier un enfant dans "MAPINFO.TB_GROUPE_CFG".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TIB_TBMODELECFG" before insert
on MAPINFO.TB_MODELE_CFG for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "MAPINFO.TB_MODELE"
	cursor c1_tb_modele_cfg(Vtb_modele__modele varchar) is
		select 1 
		from MAPINFO.TB_MODELE 
		where 
		MODELE = Vtb_modele__modele and Vtb_modele__modele is not null;
begin

	
	--  Le parent "MAPINFO.TB_MODELE" doit exister à la création d'un enfant dans "MAPINFO.TB_MODELE_CFG"
	if :new.TB_MODELE__MODELE is not null then 
		open c1_tb_modele_cfg ( :new.TB_MODELE__MODELE);
		fetch c1_tb_modele_cfg into dummy;
		found := c1_tb_modele_cfg%FOUND;
		close c1_tb_modele_cfg;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.TB_MODELE". Impossible de créer un enfant dans "MAPINFO.TB_MODELE_CFG".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TUB_TBMODELECFG" before update
on MAPINFO.TB_MODELE_CFG for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "MAPINFO.TB_MODELE"
	cursor c1_tb_modele_cfg (Vtb_modele__modele varchar) is
		select 1 
		from MAPINFO.TB_MODELE 
		where 
		MODELE = Vtb_modele__modele and Vtb_modele__modele is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "MAPINFO.TB_MODELE" doit exister à la création d'un enfant dans "MAPINFO.TB_MODELE_CFG"
	if :new.TB_MODELE__MODELE is not null and seq = 0 then 
		open c1_tb_modele_cfg ( :new.TB_MODELE__MODELE);
		fetch c1_tb_modele_cfg into dummy;
		found := c1_tb_modele_cfg%FOUND;
		close c1_tb_modele_cfg;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.TB_MODELE". Impossible de modifier un enfant dans "MAPINFO.TB_MODELE_CFG".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TIB_TBTEMPLATECFG" before insert
on MAPINFO.TB_TEMPLATE_CFG for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "MAPINFO.TB_TEMPLATE"
	cursor c1_tb_template_cfg(Vtb_modele__modele varchar,
	Vtb_template__tpl varchar) is
		select 1 
		from MAPINFO.TB_TEMPLATE 
		where 
		TB_MODELE__MODELE = Vtb_modele__modele and Vtb_modele__modele is not null and 
		TPL = Vtb_template__tpl and Vtb_template__tpl is not null;
begin

	
	--  Le parent "MAPINFO.TB_TEMPLATE" doit exister à la création d'un enfant dans "MAPINFO.TB_TEMPLATE_CFG"
	if :new.TB_MODELE__MODELE is not null and 
	:new.TB_TEMPLATE__TPL is not null then 
		open c1_tb_template_cfg ( :new.TB_MODELE__MODELE,
		:new.TB_TEMPLATE__TPL);
		fetch c1_tb_template_cfg into dummy;
		found := c1_tb_template_cfg%FOUND;
		close c1_tb_template_cfg;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.TB_TEMPLATE". Impossible de créer un enfant dans "MAPINFO.TB_TEMPLATE_CFG".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TUB_TBTEMPLATECFG" before update
on MAPINFO.TB_TEMPLATE_CFG for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "MAPINFO.TB_TEMPLATE"
	cursor c1_tb_template_cfg (Vtb_modele__modele varchar,
	Vtb_template__tpl varchar) is
		select 1 
		from MAPINFO.TB_TEMPLATE 
		where 
		TB_MODELE__MODELE = Vtb_modele__modele and Vtb_modele__modele is not null and 
		TPL = Vtb_template__tpl and Vtb_template__tpl is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "MAPINFO.TB_TEMPLATE" doit exister à la création d'un enfant dans "MAPINFO.TB_TEMPLATE_CFG"
	if :new.TB_MODELE__MODELE is not null and seq = 0 and 
	:new.TB_TEMPLATE__TPL is not null and seq = 0 then 
		open c1_tb_template_cfg ( :new.TB_MODELE__MODELE,
		:new.TB_TEMPLATE__TPL);
		fetch c1_tb_template_cfg into dummy;
		found := c1_tb_template_cfg%FOUND;
		close c1_tb_template_cfg;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.TB_TEMPLATE". Impossible de modifier un enfant dans "MAPINFO.TB_TEMPLATE_CFG".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TIB_TBGROUPE" before insert
on MAPINFO.TB_GROUPE for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "MAPINFO.TB_TEMPLATE"
	cursor c1_tb_groupe(Vtb_modele__modele varchar,
	Vtb_template__tpl varchar) is
		select 1 
		from MAPINFO.TB_TEMPLATE 
		where 
		TB_MODELE__MODELE = Vtb_modele__modele and Vtb_modele__modele is not null and 
		TPL = Vtb_template__tpl and Vtb_template__tpl is not null;
begin

	
	--  Le parent "MAPINFO.TB_TEMPLATE" doit exister à la création d'un enfant dans "MAPINFO.TB_GROUPE"
	if :new.TB_MODELE__MODELE is not null and 
	:new.TB_TEMPLATE__TPL is not null then 
		open c1_tb_groupe ( :new.TB_MODELE__MODELE,
		:new.TB_TEMPLATE__TPL);
		fetch c1_tb_groupe into dummy;
		found := c1_tb_groupe%FOUND;
		close c1_tb_groupe;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.TB_TEMPLATE". Impossible de créer un enfant dans "MAPINFO.TB_GROUPE".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TUB_TBGROUPE" before update
on MAPINFO.TB_GROUPE for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "MAPINFO.TB_TEMPLATE"
	cursor c1_tb_groupe (Vtb_modele__modele varchar,
	Vtb_template__tpl varchar) is
		select 1 
		from MAPINFO.TB_TEMPLATE 
		where 
		TB_MODELE__MODELE = Vtb_modele__modele and Vtb_modele__modele is not null and 
		TPL = Vtb_template__tpl and Vtb_template__tpl is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "MAPINFO.TB_TEMPLATE" doit exister à la création d'un enfant dans "MAPINFO.TB_GROUPE"
	if :new.TB_MODELE__MODELE is not null and seq = 0 and 
	:new.TB_TEMPLATE__TPL is not null and seq = 0 then 
		open c1_tb_groupe ( :new.TB_MODELE__MODELE,
		:new.TB_TEMPLATE__TPL);
		fetch c1_tb_groupe into dummy;
		found := c1_tb_groupe%FOUND;
		close c1_tb_groupe;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.TB_TEMPLATE". Impossible de modifier un enfant dans "MAPINFO.TB_GROUPE".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TUA_TBGROUPE" after update
of TB_MODELE__MODELE,TB_TEMPLATE__TPL,GROUPE
on MAPINFO.TB_GROUPE for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "MAPINFO.TB_GROUPE" dans les enfants "MAPINFO.TB_MAP"
	if ((updating('TB_MODELE__MODELE') and :old.TB_MODELE__MODELE != :new.TB_MODELE__MODELE) or 
	(updating('TB_TEMPLATE__TPL') and :old.TB_TEMPLATE__TPL != :new.TB_TEMPLATE__TPL) or 
	(updating('GROUPE') and :old.GROUPE != :new.GROUPE)) then 
		update MAPINFO.TB_MAP
		set TB_MODELE__MODELE = :new.TB_MODELE__MODELE,
		TB_TEMPLATE__TPL = :new.TB_TEMPLATE__TPL,
		TB_GROUPE__GROUPE = :new.GROUPE  
		where TB_MODELE__MODELE = :old.TB_MODELE__MODELE and 
		TB_TEMPLATE__TPL = :old.TB_TEMPLATE__TPL and 
		TB_GROUPE__GROUPE = :old.GROUPE;
	end if;
	--  Modification du code du parent "MAPINFO.TB_GROUPE" dans les enfants "MAPINFO.TB_GROUPE_CFG"
	if ((updating('TB_MODELE__MODELE') and :old.TB_MODELE__MODELE != :new.TB_MODELE__MODELE) or 
	(updating('TB_TEMPLATE__TPL') and :old.TB_TEMPLATE__TPL != :new.TB_TEMPLATE__TPL) or 
	(updating('GROUPE') and :old.GROUPE != :new.GROUPE)) then 
		update MAPINFO.TB_GROUPE_CFG
		set TB_MODELE__MODELE = :new.TB_MODELE__MODELE,
		TB_TEMPLATE__TPL = :new.TB_TEMPLATE__TPL,
		TB_GROUPE__GROUPE = :new.GROUPE  
		where TB_MODELE__MODELE = :old.TB_MODELE__MODELE and 
		TB_TEMPLATE__TPL = :old.TB_TEMPLATE__TPL and 
		TB_GROUPE__GROUPE = :old.GROUPE;
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


create or replace TRIGGER "MAPINFO"."TDA_TBGROUPE" after delete
on MAPINFO.TB_GROUPE for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "MAPINFO.TB_MAP"
	delete MAPINFO.TB_MAP
	where TB_MODELE__MODELE = :old.TB_MODELE__MODELE and 
	TB_TEMPLATE__TPL = :old.TB_TEMPLATE__TPL and 
	TB_GROUPE__GROUPE = :old.GROUPE;
	
	--  Suppression des enfants dans "MAPINFO.TB_GROUPE_CFG"
	delete MAPINFO.TB_GROUPE_CFG
	where TB_MODELE__MODELE = :old.TB_MODELE__MODELE and 
	TB_TEMPLATE__TPL = :old.TB_TEMPLATE__TPL and 
	TB_GROUPE__GROUPE = :old.GROUPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "MAPINFO"."TUA_TBMODELE" after update
of MODELE
on MAPINFO.TB_MODELE for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "MAPINFO.TB_MODELE" dans les enfants "MAPINFO.TB_MODELE_CFG"
	if ((updating('MODELE') and :old.MODELE != :new.MODELE)) then 
		update MAPINFO.TB_MODELE_CFG
		set TB_MODELE__MODELE = :new.MODELE  
		where TB_MODELE__MODELE = :old.MODELE;
	end if;
	--  Modification du code du parent "MAPINFO.TB_MODELE" dans les enfants "MAPINFO.TB_TEMPLATE"
	if ((updating('MODELE') and :old.MODELE != :new.MODELE)) then 
		update MAPINFO.TB_TEMPLATE
		set TB_MODELE__MODELE = :new.MODELE  
		where TB_MODELE__MODELE = :old.MODELE;
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


create or replace TRIGGER "MAPINFO"."TDA_TBMODELE" after delete
on MAPINFO.TB_MODELE for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "MAPINFO.TB_MODELE_CFG"
	delete MAPINFO.TB_MODELE_CFG
	where TB_MODELE__MODELE = :old.MODELE;
	
	--  Suppression des enfants dans "MAPINFO.TB_TEMPLATE"
	delete MAPINFO.TB_TEMPLATE
	where TB_MODELE__MODELE = :old.MODELE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "MAPINFO"."TIB_SISTYLEVALEUR" before insert
on MAPINFO.SI_STYLE_VALEUR for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "MAPINFO.SI_ZONE"
	cursor c1_si_style_valeur(Vsi_model__nom_model varchar,
	Vsi_zone__nom_zone varchar) is
		select 1 
		from MAPINFO.SI_ZONE 
		where 
		SI_MODEL__NOM_MODEL = Vsi_model__nom_model and Vsi_model__nom_model is not null and 
		NOM_ZONE = Vsi_zone__nom_zone and Vsi_zone__nom_zone is not null;
begin

	
	--  Le parent "MAPINFO.SI_ZONE" doit exister à la création d'un enfant dans "MAPINFO.SI_STYLE_VALEUR"
	if :new.SI_MODEL__NOM_MODEL is not null and 
	:new.SI_ZONE__NOM_ZONE is not null then 
		open c1_si_style_valeur ( :new.SI_MODEL__NOM_MODEL,
		:new.SI_ZONE__NOM_ZONE);
		fetch c1_si_style_valeur into dummy;
		found := c1_si_style_valeur%FOUND;
		close c1_si_style_valeur;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.SI_ZONE". Impossible de créer un enfant dans "MAPINFO.SI_STYLE_VALEUR".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TUB_SISTYLEVALEUR" before update
on MAPINFO.SI_STYLE_VALEUR for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "MAPINFO.SI_ZONE"
	cursor c1_si_style_valeur (Vsi_model__nom_model varchar,
	Vsi_zone__nom_zone varchar) is
		select 1 
		from MAPINFO.SI_ZONE 
		where 
		SI_MODEL__NOM_MODEL = Vsi_model__nom_model and Vsi_model__nom_model is not null and 
		NOM_ZONE = Vsi_zone__nom_zone and Vsi_zone__nom_zone is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "MAPINFO.SI_ZONE" doit exister à la création d'un enfant dans "MAPINFO.SI_STYLE_VALEUR"
	if :new.SI_MODEL__NOM_MODEL is not null and seq = 0 and 
	:new.SI_ZONE__NOM_ZONE is not null and seq = 0 then 
		open c1_si_style_valeur ( :new.SI_MODEL__NOM_MODEL,
		:new.SI_ZONE__NOM_ZONE);
		fetch c1_si_style_valeur into dummy;
		found := c1_si_style_valeur%FOUND;
		close c1_si_style_valeur;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.SI_ZONE". Impossible de modifier un enfant dans "MAPINFO.SI_STYLE_VALEUR".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TIB_SIZONE" before insert
on MAPINFO.SI_ZONE for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "MAPINFO.SI_MODEL"
	cursor c1_si_zone(Vsi_model__nom_model varchar) is
		select 1 
		from MAPINFO.SI_MODEL 
		where 
		NOM_MODEL = Vsi_model__nom_model and Vsi_model__nom_model is not null;
begin

	
	--  Le parent "MAPINFO.SI_MODEL" doit exister à la création d'un enfant dans "MAPINFO.SI_ZONE"
	if :new.SI_MODEL__NOM_MODEL is not null then 
		open c1_si_zone ( :new.SI_MODEL__NOM_MODEL);
		fetch c1_si_zone into dummy;
		found := c1_si_zone%FOUND;
		close c1_si_zone;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.SI_MODEL". Impossible de créer un enfant dans "MAPINFO.SI_ZONE".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TUB_SIZONE" before update
on MAPINFO.SI_ZONE for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "MAPINFO.SI_MODEL"
	cursor c1_si_zone (Vsi_model__nom_model varchar) is
		select 1 
		from MAPINFO.SI_MODEL 
		where 
		NOM_MODEL = Vsi_model__nom_model and Vsi_model__nom_model is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "MAPINFO.SI_MODEL" doit exister à la création d'un enfant dans "MAPINFO.SI_ZONE"
	if :new.SI_MODEL__NOM_MODEL is not null and seq = 0 then 
		open c1_si_zone ( :new.SI_MODEL__NOM_MODEL);
		fetch c1_si_zone into dummy;
		found := c1_si_zone%FOUND;
		close c1_si_zone;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.SI_MODEL". Impossible de modifier un enfant dans "MAPINFO.SI_ZONE".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TUA_SIZONE" after update
of SI_MODEL__NOM_MODEL,NOM_ZONE
on MAPINFO.SI_ZONE for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "MAPINFO.SI_ZONE" dans les enfants "MAPINFO.SI_STYLE_VALEUR"
	if ((updating('SI_MODEL__NOM_MODEL') and :old.SI_MODEL__NOM_MODEL != :new.SI_MODEL__NOM_MODEL) or 
	(updating('NOM_ZONE') and :old.NOM_ZONE != :new.NOM_ZONE)) then 
		update MAPINFO.SI_STYLE_VALEUR
		set SI_MODEL__NOM_MODEL = :new.SI_MODEL__NOM_MODEL,
		SI_ZONE__NOM_ZONE = :new.NOM_ZONE  
		where SI_MODEL__NOM_MODEL = :old.SI_MODEL__NOM_MODEL and 
		SI_ZONE__NOM_ZONE = :old.NOM_ZONE;
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


create or replace TRIGGER "MAPINFO"."TDA_SIZONE" after delete
on MAPINFO.SI_ZONE for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "MAPINFO.SI_STYLE_VALEUR"
	delete MAPINFO.SI_STYLE_VALEUR
	where SI_MODEL__NOM_MODEL = :old.SI_MODEL__NOM_MODEL and 
	SI_ZONE__NOM_ZONE = :old.NOM_ZONE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "MAPINFO"."TUA_SIMODEL" after update
of NOM_MODEL
on MAPINFO.SI_MODEL for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "MAPINFO.SI_MODEL" dans les enfants "MAPINFO.SI_ZONE"
	if ((updating('NOM_MODEL') and :old.NOM_MODEL != :new.NOM_MODEL)) then 
		update MAPINFO.SI_ZONE
		set SI_MODEL__NOM_MODEL = :new.NOM_MODEL  
		where SI_MODEL__NOM_MODEL = :old.NOM_MODEL;
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


create or replace TRIGGER "MAPINFO"."TDA_SIMODEL" after delete
on MAPINFO.SI_MODEL for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "MAPINFO.SI_ZONE"
	delete MAPINFO.SI_ZONE
	where SI_MODEL__NOM_MODEL = :old.NOM_MODEL;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "MAPINFO"."TUA_TBMAPMETIER" after update
of SCHEMA_NAME,TABLE_NAME
on MAPINFO.TB_MAP_METIER for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "MAPINFO.TB_MAP_METIER" dans les enfants "MAPINFO.TB_MAP_METIER_CFG"
	if ((updating('SCHEMA_NAME') and :old.SCHEMA_NAME != :new.SCHEMA_NAME) or 
	(updating('TABLE_NAME') and :old.TABLE_NAME != :new.TABLE_NAME)) then 
		update MAPINFO.TB_MAP_METIER_CFG
		set TB_MAP_METIER__SCHEMA_NAME = :new.SCHEMA_NAME,
		TB_MAP_METIER__TABLE_NAME = :new.TABLE_NAME  
		where TB_MAP_METIER__SCHEMA_NAME = :old.SCHEMA_NAME and 
		TB_MAP_METIER__TABLE_NAME = :old.TABLE_NAME;
	end if;
	--  Modification du code du parent "MAPINFO.TB_MAP_METIER" dans les enfants "MAPINFO.TB_MAP_METIER_COLUMNS"
	if ((updating('SCHEMA_NAME') and :old.SCHEMA_NAME != :new.SCHEMA_NAME) or 
	(updating('TABLE_NAME') and :old.TABLE_NAME != :new.TABLE_NAME)) then 
		update MAPINFO.TB_MAP_METIER_COLUMNS
		set TB_MAP_METIER__SCHEMA_NAME = :new.SCHEMA_NAME,
		TB_MAP_METIER__TABLE_NAME = :new.TABLE_NAME  
		where TB_MAP_METIER__SCHEMA_NAME = :old.SCHEMA_NAME and 
		TB_MAP_METIER__TABLE_NAME = :old.TABLE_NAME;
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


create or replace TRIGGER "MAPINFO"."TDA_TBMAPMETIER" after delete
on MAPINFO.TB_MAP_METIER for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "MAPINFO.TB_MAP_METIER_CFG"
	delete MAPINFO.TB_MAP_METIER_CFG
	where TB_MAP_METIER__SCHEMA_NAME = :old.SCHEMA_NAME and 
	TB_MAP_METIER__TABLE_NAME = :old.TABLE_NAME;
	
	--  Suppression des enfants dans "MAPINFO.TB_MAP_METIER_COLUMNS"
	delete MAPINFO.TB_MAP_METIER_COLUMNS
	where TB_MAP_METIER__SCHEMA_NAME = :old.SCHEMA_NAME and 
	TB_MAP_METIER__TABLE_NAME = :old.TABLE_NAME;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "MAPINFO"."TIB_TBMAPMETIERCFG" before insert
on MAPINFO.TB_MAP_METIER_CFG for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "MAPINFO.TB_MAP_METIER"
	cursor c1_tb_map_metier_cfg(Vtb_map_metier__schema_name varchar,
	Vtb_map_metier__table_name varchar) is
		select 1 
		from MAPINFO.TB_MAP_METIER 
		where 
		SCHEMA_NAME = Vtb_map_metier__schema_name and Vtb_map_metier__schema_name is not null and 
		TABLE_NAME = Vtb_map_metier__table_name and Vtb_map_metier__table_name is not null;
begin

	
	--  Le parent "MAPINFO.TB_MAP_METIER" doit exister à la création d'un enfant dans "MAPINFO.TB_MAP_METIER_CFG"
	if :new.TB_MAP_METIER__SCHEMA_NAME is not null and 
	:new.TB_MAP_METIER__TABLE_NAME is not null then 
		open c1_tb_map_metier_cfg ( :new.TB_MAP_METIER__SCHEMA_NAME,
		:new.TB_MAP_METIER__TABLE_NAME);
		fetch c1_tb_map_metier_cfg into dummy;
		found := c1_tb_map_metier_cfg%FOUND;
		close c1_tb_map_metier_cfg;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.TB_MAP_METIER". Impossible de créer un enfant dans "MAPINFO.TB_MAP_METIER_CFG".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TUB_TBMAPMETIERCFG" before update
on MAPINFO.TB_MAP_METIER_CFG for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "MAPINFO.TB_MAP_METIER"
	cursor c1_tb_map_metier_cfg (Vtb_map_metier__schema_name varchar,
	Vtb_map_metier__table_name varchar) is
		select 1 
		from MAPINFO.TB_MAP_METIER 
		where 
		SCHEMA_NAME = Vtb_map_metier__schema_name and Vtb_map_metier__schema_name is not null and 
		TABLE_NAME = Vtb_map_metier__table_name and Vtb_map_metier__table_name is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "MAPINFO.TB_MAP_METIER" doit exister à la création d'un enfant dans "MAPINFO.TB_MAP_METIER_CFG"
	if :new.TB_MAP_METIER__SCHEMA_NAME is not null and seq = 0 and 
	:new.TB_MAP_METIER__TABLE_NAME is not null and seq = 0 then 
		open c1_tb_map_metier_cfg ( :new.TB_MAP_METIER__SCHEMA_NAME,
		:new.TB_MAP_METIER__TABLE_NAME);
		fetch c1_tb_map_metier_cfg into dummy;
		found := c1_tb_map_metier_cfg%FOUND;
		close c1_tb_map_metier_cfg;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.TB_MAP_METIER". Impossible de modifier un enfant dans "MAPINFO.TB_MAP_METIER_CFG".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TIB_TBMAPMETIERCOLUMNS" before insert
on MAPINFO.TB_MAP_METIER_COLUMNS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "MAPINFO.TB_MAP_METIER"
	cursor c1_tb_map_metier_columns(Vtb_map_metier__schema_name varchar,
	Vtb_map_metier__table_name varchar) is
		select 1 
		from MAPINFO.TB_MAP_METIER 
		where 
		SCHEMA_NAME = Vtb_map_metier__schema_name and Vtb_map_metier__schema_name is not null and 
		TABLE_NAME = Vtb_map_metier__table_name and Vtb_map_metier__table_name is not null;
begin

	
	--  Le parent "MAPINFO.TB_MAP_METIER" doit exister à la création d'un enfant dans "MAPINFO.TB_MAP_METIER_COLUMNS"
	if :new.TB_MAP_METIER__SCHEMA_NAME is not null and 
	:new.TB_MAP_METIER__TABLE_NAME is not null then 
		open c1_tb_map_metier_columns ( :new.TB_MAP_METIER__SCHEMA_NAME,
		:new.TB_MAP_METIER__TABLE_NAME);
		fetch c1_tb_map_metier_columns into dummy;
		found := c1_tb_map_metier_columns%FOUND;
		close c1_tb_map_metier_columns;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.TB_MAP_METIER". Impossible de créer un enfant dans "MAPINFO.TB_MAP_METIER_COLUMNS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TUB_TBMAPMETIERCOLUMNS" before update
on MAPINFO.TB_MAP_METIER_COLUMNS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "MAPINFO.TB_MAP_METIER"
	cursor c1_tb_map_metier_columns (Vtb_map_metier__schema_name varchar,
	Vtb_map_metier__table_name varchar) is
		select 1 
		from MAPINFO.TB_MAP_METIER 
		where 
		SCHEMA_NAME = Vtb_map_metier__schema_name and Vtb_map_metier__schema_name is not null and 
		TABLE_NAME = Vtb_map_metier__table_name and Vtb_map_metier__table_name is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "MAPINFO.TB_MAP_METIER" doit exister à la création d'un enfant dans "MAPINFO.TB_MAP_METIER_COLUMNS"
	if :new.TB_MAP_METIER__SCHEMA_NAME is not null and seq = 0 and 
	:new.TB_MAP_METIER__TABLE_NAME is not null and seq = 0 then 
		open c1_tb_map_metier_columns ( :new.TB_MAP_METIER__SCHEMA_NAME,
		:new.TB_MAP_METIER__TABLE_NAME);
		fetch c1_tb_map_metier_columns into dummy;
		found := c1_tb_map_metier_columns%FOUND;
		close c1_tb_map_metier_columns;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.TB_MAP_METIER". Impossible de modifier un enfant dans "MAPINFO.TB_MAP_METIER_COLUMNS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TIB_TBTEMPLATE" before insert
on MAPINFO.TB_TEMPLATE for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "MAPINFO.TB_MODELE"
	cursor c1_tb_template(Vtb_modele__modele varchar) is
		select 1 
		from MAPINFO.TB_MODELE 
		where 
		MODELE = Vtb_modele__modele and Vtb_modele__modele is not null;
begin

	
	--  Le parent "MAPINFO.TB_MODELE" doit exister à la création d'un enfant dans "MAPINFO.TB_TEMPLATE"
	if :new.TB_MODELE__MODELE is not null then 
		open c1_tb_template ( :new.TB_MODELE__MODELE);
		fetch c1_tb_template into dummy;
		found := c1_tb_template%FOUND;
		close c1_tb_template;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.TB_MODELE". Impossible de créer un enfant dans "MAPINFO.TB_TEMPLATE".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TUB_TBTEMPLATE" before update
on MAPINFO.TB_TEMPLATE for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "MAPINFO.TB_MODELE"
	cursor c1_tb_template (Vtb_modele__modele varchar) is
		select 1 
		from MAPINFO.TB_MODELE 
		where 
		MODELE = Vtb_modele__modele and Vtb_modele__modele is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "MAPINFO.TB_MODELE" doit exister à la création d'un enfant dans "MAPINFO.TB_TEMPLATE"
	if :new.TB_MODELE__MODELE is not null and seq = 0 then 
		open c1_tb_template ( :new.TB_MODELE__MODELE);
		fetch c1_tb_template into dummy;
		found := c1_tb_template%FOUND;
		close c1_tb_template;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "MAPINFO.TB_MODELE". Impossible de modifier un enfant dans "MAPINFO.TB_TEMPLATE".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "MAPINFO"."TUA_TBTEMPLATE" after update
of TB_MODELE__MODELE,TPL
on MAPINFO.TB_TEMPLATE for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "MAPINFO.TB_TEMPLATE" dans les enfants "MAPINFO.TB_TEMPLATE_CFG"
	if ((updating('TB_MODELE__MODELE') and :old.TB_MODELE__MODELE != :new.TB_MODELE__MODELE) or 
	(updating('TPL') and :old.TPL != :new.TPL)) then 
		update MAPINFO.TB_TEMPLATE_CFG
		set TB_MODELE__MODELE = :new.TB_MODELE__MODELE,
		TB_TEMPLATE__TPL = :new.TPL  
		where TB_MODELE__MODELE = :old.TB_MODELE__MODELE and 
		TB_TEMPLATE__TPL = :old.TPL;
	end if;
	--  Modification du code du parent "MAPINFO.TB_TEMPLATE" dans les enfants "MAPINFO.TB_GROUPE"
	if ((updating('TB_MODELE__MODELE') and :old.TB_MODELE__MODELE != :new.TB_MODELE__MODELE) or 
	(updating('TPL') and :old.TPL != :new.TPL)) then 
		update MAPINFO.TB_GROUPE
		set TB_MODELE__MODELE = :new.TB_MODELE__MODELE,
		TB_TEMPLATE__TPL = :new.TPL  
		where TB_MODELE__MODELE = :old.TB_MODELE__MODELE and 
		TB_TEMPLATE__TPL = :old.TPL;
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


create or replace TRIGGER "MAPINFO"."TDA_TBTEMPLATE" after delete
on MAPINFO.TB_TEMPLATE for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "MAPINFO.TB_TEMPLATE_CFG"
	delete MAPINFO.TB_TEMPLATE_CFG
	where TB_MODELE__MODELE = :old.TB_MODELE__MODELE and 
	TB_TEMPLATE__TPL = :old.TPL;
	
	--  Suppression des enfants dans "MAPINFO.TB_GROUPE"
	delete MAPINFO.TB_GROUPE
	where TB_MODELE__MODELE = :old.TB_MODELE__MODELE and 
	TB_TEMPLATE__TPL = :old.TPL;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


