/*################################################################################################*/
/* Script     : WEB_Triggers.sql                                                                  */
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


create or replace TRIGGER "WEB"."TIB_MODELEWEBNODEWEB" before insert
on WEB.MODELE_WEB__NODE_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "WEB.NODE_WEB"
	cursor c1_modele_web__node_web(Vnode_web__id number) is
		select 1 
		from WEB.NODE_WEB 
		where 
		ID = Vnode_web__id and Vnode_web__id is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "WEB.MODELE_WEB"
	cursor c2_modele_web__node_web(Vmodele_web__id number) is
		select 1 
		from WEB.MODELE_WEB 
		where 
		ID = Vmodele_web__id and Vmodele_web__id is not null;
begin

	
	--  Le parent "WEB.NODE_WEB" doit exister à la création d'un enfant dans "WEB.MODELE_WEB__NODE_WEB"
	if :new.NODE_WEB__ID is not null then 
		open c1_modele_web__node_web ( :new.NODE_WEB__ID);
		fetch c1_modele_web__node_web into dummy;
		found := c1_modele_web__node_web%FOUND;
		close c1_modele_web__node_web;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "WEB.NODE_WEB". Impossible de créer un enfant dans "WEB.MODELE_WEB__NODE_WEB".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "WEB.MODELE_WEB" doit exister à la création d'un enfant dans "WEB.MODELE_WEB__NODE_WEB"
	if :new.MODELE_WEB__ID is not null then 
		open c2_modele_web__node_web ( :new.MODELE_WEB__ID);
		fetch c2_modele_web__node_web into dummy;
		found := c2_modele_web__node_web%FOUND;
		close c2_modele_web__node_web;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "WEB.MODELE_WEB". Impossible de créer un enfant dans "WEB.MODELE_WEB__NODE_WEB".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "WEB"."TUB_MODELEWEBNODEWEB" before update
on WEB.MODELE_WEB__NODE_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "WEB.NODE_WEB"
	cursor c1_modele_web__node_web (Vnode_web__id number) is
		select 1 
		from WEB.NODE_WEB 
		where 
		ID = Vnode_web__id and Vnode_web__id is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "WEB.MODELE_WEB"
	cursor c2_modele_web__node_web (Vmodele_web__id number) is
		select 1 
		from WEB.MODELE_WEB 
		where 
		ID = Vmodele_web__id and Vmodele_web__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "WEB.NODE_WEB" doit exister à la création d'un enfant dans "WEB.MODELE_WEB__NODE_WEB"
	if :new.NODE_WEB__ID is not null and seq = 0 then 
		open c1_modele_web__node_web ( :new.NODE_WEB__ID);
		fetch c1_modele_web__node_web into dummy;
		found := c1_modele_web__node_web%FOUND;
		close c1_modele_web__node_web;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "WEB.NODE_WEB". Impossible de modifier un enfant dans "WEB.MODELE_WEB__NODE_WEB".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "WEB.MODELE_WEB" doit exister à la création d'un enfant dans "WEB.MODELE_WEB__NODE_WEB"
	if :new.MODELE_WEB__ID is not null and seq = 0 then 
		open c2_modele_web__node_web ( :new.MODELE_WEB__ID);
		fetch c2_modele_web__node_web into dummy;
		found := c2_modele_web__node_web%FOUND;
		close c2_modele_web__node_web;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "WEB.MODELE_WEB". Impossible de modifier un enfant dans "WEB.MODELE_WEB__NODE_WEB".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "WEB"."TIB_MODELEWEB" before insert
on WEB.MODELE_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "WEB.CD_MODELE_WEB"
	cursor c1_modele_web(Vcd_modele_web__code varchar) is
		select 1 
		from WEB.CD_MODELE_WEB 
		where 
		CODE = Vcd_modele_web__code and Vcd_modele_web__code is not null;
begin

	
	--  Le parent "WEB.CD_MODELE_WEB" doit exister à la création d'un enfant dans "WEB.MODELE_WEB"
	if :new.CD_MODELE_WEB__CODE is not null then 
		open c1_modele_web ( :new.CD_MODELE_WEB__CODE);
		fetch c1_modele_web into dummy;
		found := c1_modele_web%FOUND;
		close c1_modele_web;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "WEB.CD_MODELE_WEB". Impossible de créer un enfant dans "WEB.MODELE_WEB".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "WEB"."TUB_MODELEWEB" before update
on WEB.MODELE_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "WEB.CD_MODELE_WEB"
	cursor c1_modele_web (Vcd_modele_web__code varchar) is
		select 1 
		from WEB.CD_MODELE_WEB 
		where 
		CODE = Vcd_modele_web__code and Vcd_modele_web__code is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "WEB.CD_MODELE_WEB" doit exister à la création d'un enfant dans "WEB.MODELE_WEB"
	if :new.CD_MODELE_WEB__CODE is not null and seq = 0 then 
		open c1_modele_web ( :new.CD_MODELE_WEB__CODE);
		fetch c1_modele_web into dummy;
		found := c1_modele_web%FOUND;
		close c1_modele_web;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "WEB.CD_MODELE_WEB". Impossible de modifier un enfant dans "WEB.MODELE_WEB".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "WEB"."TUA_MODELEWEB" after update
of ID
on WEB.MODELE_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "WEB.MODELE_WEB" dans les enfants "WEB.MODELE_WEB__NODE_WEB"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update WEB.MODELE_WEB__NODE_WEB
		set MODELE_WEB__ID = :new.ID  
		where MODELE_WEB__ID = :old.ID;
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


create or replace TRIGGER "WEB"."TDA_MODELEWEB" after delete
on WEB.MODELE_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "WEB.MODELE_WEB__NODE_WEB"
	delete WEB.MODELE_WEB__NODE_WEB
	where MODELE_WEB__ID = :old.ID;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "WEB"."TIB_NODEWEB" before insert
on WEB.NODE_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "WEB.CD_NODE_WEB"
	cursor c1_node_web(Vcd_node_web__name varchar) is
		select 1 
		from WEB.CD_NODE_WEB 
		where 
		NAME = Vcd_node_web__name and Vcd_node_web__name is not null;
begin

	
	--  Le parent "WEB.CD_NODE_WEB" doit exister à la création d'un enfant dans "WEB.NODE_WEB"
	if :new.CD_NODE_WEB__NAME is not null then 
		open c1_node_web ( :new.CD_NODE_WEB__NAME);
		fetch c1_node_web into dummy;
		found := c1_node_web%FOUND;
		close c1_node_web;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "WEB.CD_NODE_WEB". Impossible de créer un enfant dans "WEB.NODE_WEB".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "WEB"."TUB_NODEWEB" before update
on WEB.NODE_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "WEB.CD_NODE_WEB"
	cursor c1_node_web (Vcd_node_web__name varchar) is
		select 1 
		from WEB.CD_NODE_WEB 
		where 
		NAME = Vcd_node_web__name and Vcd_node_web__name is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "WEB.CD_NODE_WEB" doit exister à la création d'un enfant dans "WEB.NODE_WEB"
	if :new.CD_NODE_WEB__NAME is not null and seq = 0 then 
		open c1_node_web ( :new.CD_NODE_WEB__NAME);
		fetch c1_node_web into dummy;
		found := c1_node_web%FOUND;
		close c1_node_web;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "WEB.CD_NODE_WEB". Impossible de modifier un enfant dans "WEB.NODE_WEB".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "WEB"."TUA_NODEWEB" after update
of ID
on WEB.NODE_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "WEB.NODE_WEB" dans les enfants "WEB.NODE_PARAM_WEB"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update WEB.NODE_PARAM_WEB
		set NODE_WEB__ID = :new.ID  
		where NODE_WEB__ID = :old.ID;
	end if;
	--  Modification du code du parent "WEB.NODE_WEB" dans les enfants "WEB.MODELE_WEB__NODE_WEB"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update WEB.MODELE_WEB__NODE_WEB
		set NODE_WEB__ID = :new.ID  
		where NODE_WEB__ID = :old.ID;
	end if;
	--  Modification du code du parent "WEB.NODE_WEB" dans les enfants "WEB.NODE_WEB__STYLE_WEB"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update WEB.NODE_WEB__STYLE_WEB
		set NODE_WEB__ID = :new.ID  
		where NODE_WEB__ID = :old.ID;
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


create or replace TRIGGER "WEB"."TDA_NODEWEB" after delete
on WEB.NODE_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "WEB.NODE_PARAM_WEB"
	delete WEB.NODE_PARAM_WEB
	where NODE_WEB__ID = :old.ID;
	
	--  Suppression des enfants dans "WEB.MODELE_WEB__NODE_WEB"
	delete WEB.MODELE_WEB__NODE_WEB
	where NODE_WEB__ID = :old.ID;
	
	--  Suppression des enfants dans "WEB.NODE_WEB__STYLE_WEB"
	delete WEB.NODE_WEB__STYLE_WEB
	where NODE_WEB__ID = :old.ID;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "WEB"."TIB_NODEPARAMWEB" before insert
on WEB.NODE_PARAM_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "WEB.NODE_WEB"
	cursor c1_node_param_web(Vnode_web__id number) is
		select 1 
		from WEB.NODE_WEB 
		where 
		ID = Vnode_web__id and Vnode_web__id is not null;
begin

	
	--  Le parent "WEB.NODE_WEB" doit exister à la création d'un enfant dans "WEB.NODE_PARAM_WEB"
	if :new.NODE_WEB__ID is not null then 
		open c1_node_param_web ( :new.NODE_WEB__ID);
		fetch c1_node_param_web into dummy;
		found := c1_node_param_web%FOUND;
		close c1_node_param_web;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "WEB.NODE_WEB". Impossible de créer un enfant dans "WEB.NODE_PARAM_WEB".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "WEB"."TUB_NODEPARAMWEB" before update
on WEB.NODE_PARAM_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "WEB.NODE_WEB"
	cursor c1_node_param_web (Vnode_web__id number) is
		select 1 
		from WEB.NODE_WEB 
		where 
		ID = Vnode_web__id and Vnode_web__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "WEB.NODE_WEB" doit exister à la création d'un enfant dans "WEB.NODE_PARAM_WEB"
	if :new.NODE_WEB__ID is not null and seq = 0 then 
		open c1_node_param_web ( :new.NODE_WEB__ID);
		fetch c1_node_param_web into dummy;
		found := c1_node_param_web%FOUND;
		close c1_node_param_web;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "WEB.NODE_WEB". Impossible de modifier un enfant dans "WEB.NODE_PARAM_WEB".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "WEB"."TIB_STYLERULEWEB" before insert
on WEB.STYLE_RULE_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "WEB.STYLE_WEB"
	cursor c1_style_rule_web(Vstyle_web__id number) is
		select 1 
		from WEB.STYLE_WEB 
		where 
		ID = Vstyle_web__id and Vstyle_web__id is not null;
begin

	
	--  Le parent "WEB.STYLE_WEB" doit exister à la création d'un enfant dans "WEB.STYLE_RULE_WEB"
	if :new.STYLE_WEB__ID is not null then 
		open c1_style_rule_web ( :new.STYLE_WEB__ID);
		fetch c1_style_rule_web into dummy;
		found := c1_style_rule_web%FOUND;
		close c1_style_rule_web;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "WEB.STYLE_WEB". Impossible de créer un enfant dans "WEB.STYLE_RULE_WEB".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "WEB"."TUB_STYLERULEWEB" before update
on WEB.STYLE_RULE_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "WEB.STYLE_WEB"
	cursor c1_style_rule_web (Vstyle_web__id number) is
		select 1 
		from WEB.STYLE_WEB 
		where 
		ID = Vstyle_web__id and Vstyle_web__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "WEB.STYLE_WEB" doit exister à la création d'un enfant dans "WEB.STYLE_RULE_WEB"
	if :new.STYLE_WEB__ID is not null and seq = 0 then 
		open c1_style_rule_web ( :new.STYLE_WEB__ID);
		fetch c1_style_rule_web into dummy;
		found := c1_style_rule_web%FOUND;
		close c1_style_rule_web;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "WEB.STYLE_WEB". Impossible de modifier un enfant dans "WEB.STYLE_RULE_WEB".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "WEB"."TUA_STYLEWEB" after update
of ID
on WEB.STYLE_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "WEB.STYLE_WEB" dans les enfants "WEB.STYLE_RULE_WEB"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update WEB.STYLE_RULE_WEB
		set STYLE_WEB__ID = :new.ID  
		where STYLE_WEB__ID = :old.ID;
	end if;
	--  Modification du code du parent "WEB.STYLE_WEB" dans les enfants "WEB.NODE_WEB__STYLE_WEB"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update WEB.NODE_WEB__STYLE_WEB
		set STYLE_WEB__ID = :new.ID  
		where STYLE_WEB__ID = :old.ID;
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


create or replace TRIGGER "WEB"."TDA_STYLEWEB" after delete
on WEB.STYLE_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "WEB.STYLE_RULE_WEB"
	delete WEB.STYLE_RULE_WEB
	where STYLE_WEB__ID = :old.ID;
	
	--  Suppression des enfants dans "WEB.NODE_WEB__STYLE_WEB"
	delete WEB.NODE_WEB__STYLE_WEB
	where STYLE_WEB__ID = :old.ID;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "WEB"."TIB_NODEWEBSTYLEWEB" before insert
on WEB.NODE_WEB__STYLE_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "WEB.NODE_WEB"
	cursor c1_node_web__style_web(Vnode_web__id number) is
		select 1 
		from WEB.NODE_WEB 
		where 
		ID = Vnode_web__id and Vnode_web__id is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "WEB.STYLE_WEB"
	cursor c2_node_web__style_web(Vstyle_web__id number) is
		select 1 
		from WEB.STYLE_WEB 
		where 
		ID = Vstyle_web__id and Vstyle_web__id is not null;
begin

	
	--  Le parent "WEB.NODE_WEB" doit exister à la création d'un enfant dans "WEB.NODE_WEB__STYLE_WEB"
	if :new.NODE_WEB__ID is not null then 
		open c1_node_web__style_web ( :new.NODE_WEB__ID);
		fetch c1_node_web__style_web into dummy;
		found := c1_node_web__style_web%FOUND;
		close c1_node_web__style_web;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "WEB.NODE_WEB". Impossible de créer un enfant dans "WEB.NODE_WEB__STYLE_WEB".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "WEB.STYLE_WEB" doit exister à la création d'un enfant dans "WEB.NODE_WEB__STYLE_WEB"
	if :new.STYLE_WEB__ID is not null then 
		open c2_node_web__style_web ( :new.STYLE_WEB__ID);
		fetch c2_node_web__style_web into dummy;
		found := c2_node_web__style_web%FOUND;
		close c2_node_web__style_web;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "WEB.STYLE_WEB". Impossible de créer un enfant dans "WEB.NODE_WEB__STYLE_WEB".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "WEB"."TUB_NODEWEBSTYLEWEB" before update
on WEB.NODE_WEB__STYLE_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "WEB.NODE_WEB"
	cursor c1_node_web__style_web (Vnode_web__id number) is
		select 1 
		from WEB.NODE_WEB 
		where 
		ID = Vnode_web__id and Vnode_web__id is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "WEB.STYLE_WEB"
	cursor c2_node_web__style_web (Vstyle_web__id number) is
		select 1 
		from WEB.STYLE_WEB 
		where 
		ID = Vstyle_web__id and Vstyle_web__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "WEB.NODE_WEB" doit exister à la création d'un enfant dans "WEB.NODE_WEB__STYLE_WEB"
	if :new.NODE_WEB__ID is not null and seq = 0 then 
		open c1_node_web__style_web ( :new.NODE_WEB__ID);
		fetch c1_node_web__style_web into dummy;
		found := c1_node_web__style_web%FOUND;
		close c1_node_web__style_web;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "WEB.NODE_WEB". Impossible de modifier un enfant dans "WEB.NODE_WEB__STYLE_WEB".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "WEB.STYLE_WEB" doit exister à la création d'un enfant dans "WEB.NODE_WEB__STYLE_WEB"
	if :new.STYLE_WEB__ID is not null and seq = 0 then 
		open c2_node_web__style_web ( :new.STYLE_WEB__ID);
		fetch c2_node_web__style_web into dummy;
		found := c2_node_web__style_web%FOUND;
		close c2_node_web__style_web;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "WEB.STYLE_WEB". Impossible de modifier un enfant dans "WEB.NODE_WEB__STYLE_WEB".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "WEB"."TUA_CDMODELEWEB" after update
of CODE
on WEB.CD_MODELE_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "WEB.CD_MODELE_WEB" dans les enfants "WEB.MODELE_WEB"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update WEB.MODELE_WEB
		set CD_MODELE_WEB__CODE = :new.CODE  
		where CD_MODELE_WEB__CODE = :old.CODE;
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


create or replace TRIGGER "WEB"."TDA_CDMODELEWEB" after delete
on WEB.CD_MODELE_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "WEB.MODELE_WEB"
	delete WEB.MODELE_WEB
	where CD_MODELE_WEB__CODE = :old.CODE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "WEB"."TUA_CDNODEWEB" after update
of NAME
on WEB.CD_NODE_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "WEB.CD_NODE_WEB" dans les enfants "WEB.NODE_WEB"
	if ((updating('NAME') and :old.NAME != :new.NAME)) then 
		update WEB.NODE_WEB
		set CD_NODE_WEB__NAME = :new.NAME  
		where CD_NODE_WEB__NAME = :old.NAME;
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


create or replace TRIGGER "WEB"."TDA_CDNODEWEB" after delete
on WEB.CD_NODE_WEB for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "WEB.NODE_WEB"
	delete WEB.NODE_WEB
	where CD_NODE_WEB__NAME = :old.NAME;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


