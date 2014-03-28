/*################################################################################################*/
/* Script     : DS_Triggers.sql                                                                   */
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


create or replace TRIGGER "DS"."TUA_MATDS" after update
of CODE
on DS.MAT_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "DS.MAT_DS" dans les enfants "DS.MAT_PARAM_DS"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update DS.MAT_PARAM_DS
		set MAT_DS__CODE = :new.CODE  
		where MAT_DS__CODE = :old.CODE;
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


create or replace TRIGGER "DS"."TDA_MATDS" after delete
on DS.MAT_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "DS.MAT_PARAM_DS"
	delete DS.MAT_PARAM_DS
	where MAT_DS__CODE = :old.CODE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "DS"."TIB_MATPARAMDS" before insert
on DS.MAT_PARAM_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.MAT_DS"
	cursor c1_mat_param_ds(Vmat_ds__code varchar) is
		select 1 
		from DS.MAT_DS 
		where 
		CODE = Vmat_ds__code and Vmat_ds__code is not null;
begin

	
	--  Le parent "DS.MAT_DS" doit exister à la création d'un enfant dans "DS.MAT_PARAM_DS"
	if :new.MAT_DS__CODE is not null then 
		open c1_mat_param_ds ( :new.MAT_DS__CODE);
		fetch c1_mat_param_ds into dummy;
		found := c1_mat_param_ds%FOUND;
		close c1_mat_param_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.MAT_DS". Impossible de créer un enfant dans "DS.MAT_PARAM_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUB_MATPARAMDS" before update
on DS.MAT_PARAM_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.MAT_DS"
	cursor c1_mat_param_ds (Vmat_ds__code varchar) is
		select 1 
		from DS.MAT_DS 
		where 
		CODE = Vmat_ds__code and Vmat_ds__code is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "DS.MAT_DS" doit exister à la création d'un enfant dans "DS.MAT_PARAM_DS"
	if :new.MAT_DS__CODE is not null and seq = 0 then 
		open c1_mat_param_ds ( :new.MAT_DS__CODE);
		fetch c1_mat_param_ds into dummy;
		found := c1_mat_param_ds%FOUND;
		close c1_mat_param_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.MAT_DS". Impossible de modifier un enfant dans "DS.MAT_PARAM_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TIB_NODEDS" before insert
on DS.NODE_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.TREE_DS"
	cursor c1_node_ds(Vtree_ds__id number) is
		select 1 
		from DS.TREE_DS 
		where 
		ID = Vtree_ds__id and Vtree_ds__id is not null;
begin

	
	--  Le parent "DS.TREE_DS" doit exister à la création d'un enfant dans "DS.NODE_DS"
	if :new.TREE_DS__ID is not null then 
		open c1_node_ds ( :new.TREE_DS__ID);
		fetch c1_node_ds into dummy;
		found := c1_node_ds%FOUND;
		close c1_node_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.TREE_DS". Impossible de créer un enfant dans "DS.NODE_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUB_NODEDS" before update
on DS.NODE_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.TREE_DS"
	cursor c1_node_ds (Vtree_ds__id number) is
		select 1 
		from DS.TREE_DS 
		where 
		ID = Vtree_ds__id and Vtree_ds__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "DS.TREE_DS" doit exister à la création d'un enfant dans "DS.NODE_DS"
	if :new.TREE_DS__ID is not null and seq = 0 then 
		open c1_node_ds ( :new.TREE_DS__ID);
		fetch c1_node_ds into dummy;
		found := c1_node_ds%FOUND;
		close c1_node_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.TREE_DS". Impossible de modifier un enfant dans "DS.NODE_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUA_NODEDS" after update
of TREE_DS__ID,ID
on DS.NODE_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "DS.NODE_DS" dans les enfants "DS.NODE_PARAM_DS"
	if ((updating('TREE_DS__ID') and :old.TREE_DS__ID != :new.TREE_DS__ID) or 
	(updating('ID') and :old.ID != :new.ID)) then 
		update DS.NODE_PARAM_DS
		set TREE_DS__ID = :new.TREE_DS__ID,
		NODE_DS__ID = :new.ID  
		where TREE_DS__ID = :old.TREE_DS__ID and 
		NODE_DS__ID = :old.ID;
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


create or replace TRIGGER "DS"."TDA_NODEDS" after delete
on DS.NODE_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "DS.NODE_PARAM_DS"
	delete DS.NODE_PARAM_DS
	where TREE_DS__ID = :old.TREE_DS__ID and 
	NODE_DS__ID = :old.ID;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "DS"."TIB_NODEPARAMDS" before insert
on DS.NODE_PARAM_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.NODE_DS"
	cursor c1_node_param_ds(Vtree_ds__id number,
	Vnode_ds__id number) is
		select 1 
		from DS.NODE_DS 
		where 
		TREE_DS__ID = Vtree_ds__id and Vtree_ds__id is not null and 
		ID = Vnode_ds__id and Vnode_ds__id is not null;
begin

	
	--  Le parent "DS.NODE_DS" doit exister à la création d'un enfant dans "DS.NODE_PARAM_DS"
	if :new.TREE_DS__ID is not null and 
	:new.NODE_DS__ID is not null then 
		open c1_node_param_ds ( :new.TREE_DS__ID,
		:new.NODE_DS__ID);
		fetch c1_node_param_ds into dummy;
		found := c1_node_param_ds%FOUND;
		close c1_node_param_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.NODE_DS". Impossible de créer un enfant dans "DS.NODE_PARAM_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUB_NODEPARAMDS" before update
on DS.NODE_PARAM_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.NODE_DS"
	cursor c1_node_param_ds (Vtree_ds__id number,
	Vnode_ds__id number) is
		select 1 
		from DS.NODE_DS 
		where 
		TREE_DS__ID = Vtree_ds__id and Vtree_ds__id is not null and 
		ID = Vnode_ds__id and Vnode_ds__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "DS.NODE_DS" doit exister à la création d'un enfant dans "DS.NODE_PARAM_DS"
	if :new.TREE_DS__ID is not null and seq = 0 and 
	:new.NODE_DS__ID is not null and seq = 0 then 
		open c1_node_param_ds ( :new.TREE_DS__ID,
		:new.NODE_DS__ID);
		fetch c1_node_param_ds into dummy;
		found := c1_node_param_ds%FOUND;
		close c1_node_param_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.NODE_DS". Impossible de modifier un enfant dans "DS.NODE_PARAM_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUA_PONDS" after update
of CODE
on DS.PON_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "DS.PON_DS" dans les enfants "DS.PON_PARAM_DS"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update DS.PON_PARAM_DS
		set PON_DS__CODE = :new.CODE  
		where PON_DS__CODE = :old.CODE;
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


create or replace TRIGGER "DS"."TDA_PONDS" after delete
on DS.PON_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "DS.PON_PARAM_DS"
	delete DS.PON_PARAM_DS
	where PON_DS__CODE = :old.CODE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "DS"."TIB_PONPARAMDS" before insert
on DS.PON_PARAM_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.PON_DS"
	cursor c1_pon_param_ds(Vpon_ds__code varchar) is
		select 1 
		from DS.PON_DS 
		where 
		CODE = Vpon_ds__code and Vpon_ds__code is not null;
begin

	
	--  Le parent "DS.PON_DS" doit exister à la création d'un enfant dans "DS.PON_PARAM_DS"
	if :new.PON_DS__CODE is not null then 
		open c1_pon_param_ds ( :new.PON_DS__CODE);
		fetch c1_pon_param_ds into dummy;
		found := c1_pon_param_ds%FOUND;
		close c1_pon_param_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.PON_DS". Impossible de créer un enfant dans "DS.PON_PARAM_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUB_PONPARAMDS" before update
on DS.PON_PARAM_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.PON_DS"
	cursor c1_pon_param_ds (Vpon_ds__code varchar) is
		select 1 
		from DS.PON_DS 
		where 
		CODE = Vpon_ds__code and Vpon_ds__code is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "DS.PON_DS" doit exister à la création d'un enfant dans "DS.PON_PARAM_DS"
	if :new.PON_DS__CODE is not null and seq = 0 then 
		open c1_pon_param_ds ( :new.PON_DS__CODE);
		fetch c1_pon_param_ds into dummy;
		found := c1_pon_param_ds%FOUND;
		close c1_pon_param_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.PON_DS". Impossible de modifier un enfant dans "DS.PON_PARAM_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TIB_SIMCALCULDS" before insert
on DS.SIM_CALCUL_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.SIM_ETUDE_DS"
	cursor c1_sim_calcul_ds(Vsim_etude_ds__id number) is
		select 1 
		from DS.SIM_ETUDE_DS 
		where 
		ID = Vsim_etude_ds__id and Vsim_etude_ds__id is not null;
begin

	
	--  Le parent "DS.SIM_ETUDE_DS" doit exister à la création d'un enfant dans "DS.SIM_CALCUL_DS"
	if :new.SIM_ETUDE_DS__ID is not null then 
		open c1_sim_calcul_ds ( :new.SIM_ETUDE_DS__ID);
		fetch c1_sim_calcul_ds into dummy;
		found := c1_sim_calcul_ds%FOUND;
		close c1_sim_calcul_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_ETUDE_DS". Impossible de créer un enfant dans "DS.SIM_CALCUL_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUB_SIMCALCULDS" before update
on DS.SIM_CALCUL_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.SIM_ETUDE_DS"
	cursor c1_sim_calcul_ds (Vsim_etude_ds__id number) is
		select 1 
		from DS.SIM_ETUDE_DS 
		where 
		ID = Vsim_etude_ds__id and Vsim_etude_ds__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "DS.SIM_ETUDE_DS" doit exister à la création d'un enfant dans "DS.SIM_CALCUL_DS"
	if :new.SIM_ETUDE_DS__ID is not null and seq = 0 then 
		open c1_sim_calcul_ds ( :new.SIM_ETUDE_DS__ID);
		fetch c1_sim_calcul_ds into dummy;
		found := c1_sim_calcul_ds%FOUND;
		close c1_sim_calcul_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_ETUDE_DS". Impossible de modifier un enfant dans "DS.SIM_CALCUL_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUA_SIMCALCULDS" after update
of ID
on DS.SIM_CALCUL_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "DS.SIM_CALCUL_DS" dans les enfants "DS.SIM_CALCUL_TRAFIC_DS"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update DS.SIM_CALCUL_TRAFIC_DS
		set SIM_CALCUL_DS__ID = :new.ID  
		where SIM_CALCUL_DS__ID = :old.ID;
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


create or replace TRIGGER "DS"."TDA_SIMCALCULDS" after delete
on DS.SIM_CALCUL_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "DS.SIM_CALCUL_TRAFIC_DS"
	delete DS.SIM_CALCUL_TRAFIC_DS
	where SIM_CALCUL_DS__ID = :old.ID;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "DS"."TIB_SIMCALCULFISDS" before insert
on DS.SIM_CALCUL_FIS_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.SIM_CALCUL_TRAFIC_DS"
	cursor c1_sim_calcul_fis_ds(Vsim_calcul_trafic_ds__id number) is
		select 1 
		from DS.SIM_CALCUL_TRAFIC_DS 
		where 
		ID = Vsim_calcul_trafic_ds__id and Vsim_calcul_trafic_ds__id is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.SIM_FIS_DS"
	cursor c2_sim_calcul_fis_ds(Vsim_fis_ds__id number) is
		select 1 
		from DS.SIM_FIS_DS 
		where 
		ID = Vsim_fis_ds__id and Vsim_fis_ds__id is not null;
begin

	
	--  Le parent "DS.SIM_CALCUL_TRAFIC_DS" doit exister à la création d'un enfant dans "DS.SIM_CALCUL_FIS_DS"
	if :new.SIM_CALCUL_TRAFIC_DS__ID is not null then 
		open c1_sim_calcul_fis_ds ( :new.SIM_CALCUL_TRAFIC_DS__ID);
		fetch c1_sim_calcul_fis_ds into dummy;
		found := c1_sim_calcul_fis_ds%FOUND;
		close c1_sim_calcul_fis_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_CALCUL_TRAFIC_DS". Impossible de créer un enfant dans "DS.SIM_CALCUL_FIS_DS".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "DS.SIM_FIS_DS" doit exister à la création d'un enfant dans "DS.SIM_CALCUL_FIS_DS"
	if :new.SIM_FIS_DS__ID is not null then 
		open c2_sim_calcul_fis_ds ( :new.SIM_FIS_DS__ID);
		fetch c2_sim_calcul_fis_ds into dummy;
		found := c2_sim_calcul_fis_ds%FOUND;
		close c2_sim_calcul_fis_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_FIS_DS". Impossible de créer un enfant dans "DS.SIM_CALCUL_FIS_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUB_SIMCALCULFISDS" before update
on DS.SIM_CALCUL_FIS_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.SIM_CALCUL_TRAFIC_DS"
	cursor c1_sim_calcul_fis_ds (Vsim_calcul_trafic_ds__id number) is
		select 1 
		from DS.SIM_CALCUL_TRAFIC_DS 
		where 
		ID = Vsim_calcul_trafic_ds__id and Vsim_calcul_trafic_ds__id is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.SIM_FIS_DS"
	cursor c2_sim_calcul_fis_ds (Vsim_fis_ds__id number) is
		select 1 
		from DS.SIM_FIS_DS 
		where 
		ID = Vsim_fis_ds__id and Vsim_fis_ds__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "DS.SIM_CALCUL_TRAFIC_DS" doit exister à la création d'un enfant dans "DS.SIM_CALCUL_FIS_DS"
	if :new.SIM_CALCUL_TRAFIC_DS__ID is not null and seq = 0 then 
		open c1_sim_calcul_fis_ds ( :new.SIM_CALCUL_TRAFIC_DS__ID);
		fetch c1_sim_calcul_fis_ds into dummy;
		found := c1_sim_calcul_fis_ds%FOUND;
		close c1_sim_calcul_fis_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_CALCUL_TRAFIC_DS". Impossible de modifier un enfant dans "DS.SIM_CALCUL_FIS_DS".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "DS.SIM_FIS_DS" doit exister à la création d'un enfant dans "DS.SIM_CALCUL_FIS_DS"
	if :new.SIM_FIS_DS__ID is not null and seq = 0 then 
		open c2_sim_calcul_fis_ds ( :new.SIM_FIS_DS__ID);
		fetch c2_sim_calcul_fis_ds into dummy;
		found := c2_sim_calcul_fis_ds%FOUND;
		close c2_sim_calcul_fis_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_FIS_DS". Impossible de modifier un enfant dans "DS.SIM_CALCUL_FIS_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUA_SIMCALCULFISDS" after update
of SIM_CALCUL_TRAFIC_DS__ID,SIM_FIS_DS__ID
on DS.SIM_CALCUL_FIS_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "DS.SIM_CALCUL_FIS_DS" dans les enfants "DS.SIM_RESULT_DS"
	if ((updating('SIM_CALCUL_TRAFIC_DS__ID') and :old.SIM_CALCUL_TRAFIC_DS__ID != :new.SIM_CALCUL_TRAFIC_DS__ID) or 
	(updating('SIM_FIS_DS__ID') and :old.SIM_FIS_DS__ID != :new.SIM_FIS_DS__ID)) then 
		update DS.SIM_RESULT_DS
		set SIM_CALCUL_TRAFIC_DS__ID = :new.SIM_CALCUL_TRAFIC_DS__ID,
		SIM_FIS_DS__ID = :new.SIM_FIS_DS__ID  
		where SIM_CALCUL_TRAFIC_DS__ID = :old.SIM_CALCUL_TRAFIC_DS__ID and 
		SIM_FIS_DS__ID = :old.SIM_FIS_DS__ID;
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


create or replace TRIGGER "DS"."TDA_SIMCALCULFISDS" after delete
on DS.SIM_CALCUL_FIS_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "DS.SIM_RESULT_DS"
	delete DS.SIM_RESULT_DS
	where SIM_CALCUL_TRAFIC_DS__ID = :old.SIM_CALCUL_TRAFIC_DS__ID and 
	SIM_FIS_DS__ID = :old.SIM_FIS_DS__ID;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "DS"."TIB_SIMCALCULTRAFICDS" before insert
on DS.SIM_CALCUL_TRAFIC_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.SIM_DVP_DS"
	cursor c1_sim_calcul_trafic_ds(Vsim_dvp_ds__id number) is
		select 1 
		from DS.SIM_DVP_DS 
		where 
		ID = Vsim_dvp_ds__id and Vsim_dvp_ds__id is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.SIM_REC_DS"
	cursor c2_sim_calcul_trafic_ds(Vsim_rec_ds__id number) is
		select 1 
		from DS.SIM_REC_DS 
		where 
		ID = Vsim_rec_ds__id and Vsim_rec_ds__id is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.SIM_ENTRETIEN_DS"
	cursor c3_sim_calcul_trafic_ds(Vsim_entretien_ds__id number) is
		select 1 
		from DS.SIM_ENTRETIEN_DS 
		where 
		ID = Vsim_entretien_ds__id and Vsim_entretien_ds__id is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.SIM_CALCUL_DS"
	cursor c4_sim_calcul_trafic_ds(Vsim_calcul_ds__id number) is
		select 1 
		from DS.SIM_CALCUL_DS 
		where 
		ID = Vsim_calcul_ds__id and Vsim_calcul_ds__id is not null;
begin

	
	--  Le parent "DS.SIM_DVP_DS" doit exister à la création d'un enfant dans "DS.SIM_CALCUL_TRAFIC_DS"
	if :new.SIM_DVP_DS__ID is not null then 
		open c1_sim_calcul_trafic_ds ( :new.SIM_DVP_DS__ID);
		fetch c1_sim_calcul_trafic_ds into dummy;
		found := c1_sim_calcul_trafic_ds%FOUND;
		close c1_sim_calcul_trafic_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_DVP_DS". Impossible de créer un enfant dans "DS.SIM_CALCUL_TRAFIC_DS".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "DS.SIM_REC_DS" doit exister à la création d'un enfant dans "DS.SIM_CALCUL_TRAFIC_DS"
	if :new.SIM_REC_DS__ID is not null then 
		open c2_sim_calcul_trafic_ds ( :new.SIM_REC_DS__ID);
		fetch c2_sim_calcul_trafic_ds into dummy;
		found := c2_sim_calcul_trafic_ds%FOUND;
		close c2_sim_calcul_trafic_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_REC_DS". Impossible de créer un enfant dans "DS.SIM_CALCUL_TRAFIC_DS".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "DS.SIM_ENTRETIEN_DS" doit exister à la création d'un enfant dans "DS.SIM_CALCUL_TRAFIC_DS"
	if :new.SIM_ENTRETIEN_DS__ID is not null then 
		open c3_sim_calcul_trafic_ds ( :new.SIM_ENTRETIEN_DS__ID);
		fetch c3_sim_calcul_trafic_ds into dummy;
		found := c3_sim_calcul_trafic_ds%FOUND;
		close c3_sim_calcul_trafic_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_ENTRETIEN_DS". Impossible de créer un enfant dans "DS.SIM_CALCUL_TRAFIC_DS".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "DS.SIM_CALCUL_DS" doit exister à la création d'un enfant dans "DS.SIM_CALCUL_TRAFIC_DS"
	if :new.SIM_CALCUL_DS__ID is not null then 
		open c4_sim_calcul_trafic_ds ( :new.SIM_CALCUL_DS__ID);
		fetch c4_sim_calcul_trafic_ds into dummy;
		found := c4_sim_calcul_trafic_ds%FOUND;
		close c4_sim_calcul_trafic_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_CALCUL_DS". Impossible de créer un enfant dans "DS.SIM_CALCUL_TRAFIC_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUB_SIMCALCULTRAFICDS" before update
on DS.SIM_CALCUL_TRAFIC_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.SIM_DVP_DS"
	cursor c1_sim_calcul_trafic_ds (Vsim_dvp_ds__id number) is
		select 1 
		from DS.SIM_DVP_DS 
		where 
		ID = Vsim_dvp_ds__id and Vsim_dvp_ds__id is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.SIM_REC_DS"
	cursor c2_sim_calcul_trafic_ds (Vsim_rec_ds__id number) is
		select 1 
		from DS.SIM_REC_DS 
		where 
		ID = Vsim_rec_ds__id and Vsim_rec_ds__id is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.SIM_ENTRETIEN_DS"
	cursor c3_sim_calcul_trafic_ds (Vsim_entretien_ds__id number) is
		select 1 
		from DS.SIM_ENTRETIEN_DS 
		where 
		ID = Vsim_entretien_ds__id and Vsim_entretien_ds__id is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.SIM_CALCUL_DS"
	cursor c4_sim_calcul_trafic_ds (Vsim_calcul_ds__id number) is
		select 1 
		from DS.SIM_CALCUL_DS 
		where 
		ID = Vsim_calcul_ds__id and Vsim_calcul_ds__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "DS.SIM_DVP_DS" doit exister à la création d'un enfant dans "DS.SIM_CALCUL_TRAFIC_DS"
	if :new.SIM_DVP_DS__ID is not null and seq = 0 then 
		open c1_sim_calcul_trafic_ds ( :new.SIM_DVP_DS__ID);
		fetch c1_sim_calcul_trafic_ds into dummy;
		found := c1_sim_calcul_trafic_ds%FOUND;
		close c1_sim_calcul_trafic_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_DVP_DS". Impossible de modifier un enfant dans "DS.SIM_CALCUL_TRAFIC_DS".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "DS.SIM_REC_DS" doit exister à la création d'un enfant dans "DS.SIM_CALCUL_TRAFIC_DS"
	if :new.SIM_REC_DS__ID is not null and seq = 0 then 
		open c2_sim_calcul_trafic_ds ( :new.SIM_REC_DS__ID);
		fetch c2_sim_calcul_trafic_ds into dummy;
		found := c2_sim_calcul_trafic_ds%FOUND;
		close c2_sim_calcul_trafic_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_REC_DS". Impossible de modifier un enfant dans "DS.SIM_CALCUL_TRAFIC_DS".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "DS.SIM_ENTRETIEN_DS" doit exister à la création d'un enfant dans "DS.SIM_CALCUL_TRAFIC_DS"
	if :new.SIM_ENTRETIEN_DS__ID is not null and seq = 0 then 
		open c3_sim_calcul_trafic_ds ( :new.SIM_ENTRETIEN_DS__ID);
		fetch c3_sim_calcul_trafic_ds into dummy;
		found := c3_sim_calcul_trafic_ds%FOUND;
		close c3_sim_calcul_trafic_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_ENTRETIEN_DS". Impossible de modifier un enfant dans "DS.SIM_CALCUL_TRAFIC_DS".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "DS.SIM_CALCUL_DS" doit exister à la création d'un enfant dans "DS.SIM_CALCUL_TRAFIC_DS"
	if :new.SIM_CALCUL_DS__ID is not null and seq = 0 then 
		open c4_sim_calcul_trafic_ds ( :new.SIM_CALCUL_DS__ID);
		fetch c4_sim_calcul_trafic_ds into dummy;
		found := c4_sim_calcul_trafic_ds%FOUND;
		close c4_sim_calcul_trafic_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_CALCUL_DS". Impossible de modifier un enfant dans "DS.SIM_CALCUL_TRAFIC_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUA_SIMCALCULTRAFICDS" after update
of ID
on DS.SIM_CALCUL_TRAFIC_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "DS.SIM_CALCUL_TRAFIC_DS" dans les enfants "DS.SIM_CALCUL_FIS_DS"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update DS.SIM_CALCUL_FIS_DS
		set SIM_CALCUL_TRAFIC_DS__ID = :new.ID  
		where SIM_CALCUL_TRAFIC_DS__ID = :old.ID;
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


create or replace TRIGGER "DS"."TDA_SIMCALCULTRAFICDS" after delete
on DS.SIM_CALCUL_TRAFIC_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "DS.SIM_CALCUL_FIS_DS"
	delete DS.SIM_CALCUL_FIS_DS
	where SIM_CALCUL_TRAFIC_DS__ID = :old.ID;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "DS"."TIB_SIMDVPDS" before insert
on DS.SIM_DVP_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.SIM_ETUDE_DS"
	cursor c1_sim_dvp_ds(Vsim_etude_ds__id number) is
		select 1 
		from DS.SIM_ETUDE_DS 
		where 
		ID = Vsim_etude_ds__id and Vsim_etude_ds__id is not null;
begin

	
	--  Le parent "DS.SIM_ETUDE_DS" doit exister à la création d'un enfant dans "DS.SIM_DVP_DS"
	if :new.SIM_ETUDE_DS__ID is not null then 
		open c1_sim_dvp_ds ( :new.SIM_ETUDE_DS__ID);
		fetch c1_sim_dvp_ds into dummy;
		found := c1_sim_dvp_ds%FOUND;
		close c1_sim_dvp_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_ETUDE_DS". Impossible de créer un enfant dans "DS.SIM_DVP_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUB_SIMDVPDS" before update
on DS.SIM_DVP_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.SIM_ETUDE_DS"
	cursor c1_sim_dvp_ds (Vsim_etude_ds__id number) is
		select 1 
		from DS.SIM_ETUDE_DS 
		where 
		ID = Vsim_etude_ds__id and Vsim_etude_ds__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "DS.SIM_ETUDE_DS" doit exister à la création d'un enfant dans "DS.SIM_DVP_DS"
	if :new.SIM_ETUDE_DS__ID is not null and seq = 0 then 
		open c1_sim_dvp_ds ( :new.SIM_ETUDE_DS__ID);
		fetch c1_sim_dvp_ds into dummy;
		found := c1_sim_dvp_ds%FOUND;
		close c1_sim_dvp_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_ETUDE_DS". Impossible de modifier un enfant dans "DS.SIM_DVP_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUA_SIMDVPDS" after update
of ID
on DS.SIM_DVP_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "DS.SIM_DVP_DS" dans les enfants "DS.SIM_CALCUL_TRAFIC_DS"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update DS.SIM_CALCUL_TRAFIC_DS
		set SIM_DVP_DS__ID = :new.ID  
		where SIM_DVP_DS__ID = :old.ID;
	end if;
	--  Modification du code du parent "DS.SIM_DVP_DS" dans les enfants "DS.SIM_DVP_VALUES_DS"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update DS.SIM_DVP_VALUES_DS
		set SIM_DVP_DS__ID = :new.ID  
		where SIM_DVP_DS__ID = :old.ID;
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


create or replace TRIGGER "DS"."TDA_SIMDVPDS" after delete
on DS.SIM_DVP_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "DS.SIM_CALCUL_TRAFIC_DS"
	delete DS.SIM_CALCUL_TRAFIC_DS
	where SIM_DVP_DS__ID = :old.ID;
	
	--  Suppression des enfants dans "DS.SIM_DVP_VALUES_DS"
	delete DS.SIM_DVP_VALUES_DS
	where SIM_DVP_DS__ID = :old.ID;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "DS"."TIB_SIMDVPVALUESDS" before insert
on DS.SIM_DVP_VALUES_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.SIM_DVP_DS"
	cursor c1_sim_dvp_values_ds(Vsim_dvp_ds__id number) is
		select 1 
		from DS.SIM_DVP_DS 
		where 
		ID = Vsim_dvp_ds__id and Vsim_dvp_ds__id is not null;
begin

	
	--  Le parent "DS.SIM_DVP_DS" doit exister à la création d'un enfant dans "DS.SIM_DVP_VALUES_DS"
	if :new.SIM_DVP_DS__ID is not null then 
		open c1_sim_dvp_values_ds ( :new.SIM_DVP_DS__ID);
		fetch c1_sim_dvp_values_ds into dummy;
		found := c1_sim_dvp_values_ds%FOUND;
		close c1_sim_dvp_values_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_DVP_DS". Impossible de créer un enfant dans "DS.SIM_DVP_VALUES_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUB_SIMDVPVALUESDS" before update
on DS.SIM_DVP_VALUES_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.SIM_DVP_DS"
	cursor c1_sim_dvp_values_ds (Vsim_dvp_ds__id number) is
		select 1 
		from DS.SIM_DVP_DS 
		where 
		ID = Vsim_dvp_ds__id and Vsim_dvp_ds__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "DS.SIM_DVP_DS" doit exister à la création d'un enfant dans "DS.SIM_DVP_VALUES_DS"
	if :new.SIM_DVP_DS__ID is not null and seq = 0 then 
		open c1_sim_dvp_values_ds ( :new.SIM_DVP_DS__ID);
		fetch c1_sim_dvp_values_ds into dummy;
		found := c1_sim_dvp_values_ds%FOUND;
		close c1_sim_dvp_values_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_DVP_DS". Impossible de modifier un enfant dans "DS.SIM_DVP_VALUES_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TIB_SIMENTRETIENDS" before insert
on DS.SIM_ENTRETIEN_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.SIM_ETUDE_DS"
	cursor c1_sim_entretien_ds(Vsim_etude_ds__id number) is
		select 1 
		from DS.SIM_ETUDE_DS 
		where 
		ID = Vsim_etude_ds__id and Vsim_etude_ds__id is not null;
begin

	
	--  Le parent "DS.SIM_ETUDE_DS" doit exister à la création d'un enfant dans "DS.SIM_ENTRETIEN_DS"
	if :new.SIM_ETUDE_DS__ID is not null then 
		open c1_sim_entretien_ds ( :new.SIM_ETUDE_DS__ID);
		fetch c1_sim_entretien_ds into dummy;
		found := c1_sim_entretien_ds%FOUND;
		close c1_sim_entretien_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_ETUDE_DS". Impossible de créer un enfant dans "DS.SIM_ENTRETIEN_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUB_SIMENTRETIENDS" before update
on DS.SIM_ENTRETIEN_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.SIM_ETUDE_DS"
	cursor c1_sim_entretien_ds (Vsim_etude_ds__id number) is
		select 1 
		from DS.SIM_ETUDE_DS 
		where 
		ID = Vsim_etude_ds__id and Vsim_etude_ds__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "DS.SIM_ETUDE_DS" doit exister à la création d'un enfant dans "DS.SIM_ENTRETIEN_DS"
	if :new.SIM_ETUDE_DS__ID is not null and seq = 0 then 
		open c1_sim_entretien_ds ( :new.SIM_ETUDE_DS__ID);
		fetch c1_sim_entretien_ds into dummy;
		found := c1_sim_entretien_ds%FOUND;
		close c1_sim_entretien_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_ETUDE_DS". Impossible de modifier un enfant dans "DS.SIM_ENTRETIEN_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUA_SIMENTRETIENDS" after update
of ID
on DS.SIM_ENTRETIEN_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "DS.SIM_ENTRETIEN_DS" dans les enfants "DS.SIM_CALCUL_TRAFIC_DS"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update DS.SIM_CALCUL_TRAFIC_DS
		set SIM_ENTRETIEN_DS__ID = :new.ID  
		where SIM_ENTRETIEN_DS__ID = :old.ID;
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


create or replace TRIGGER "DS"."TDA_SIMENTRETIENDS" after delete
on DS.SIM_ENTRETIEN_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "DS.SIM_CALCUL_TRAFIC_DS"
	delete DS.SIM_CALCUL_TRAFIC_DS
	where SIM_ENTRETIEN_DS__ID = :old.ID;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "DS"."TUA_SIMETUDEDS" after update
of ID
on DS.SIM_ETUDE_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "DS.SIM_ETUDE_DS" dans les enfants "DS.SIM_FIS_DS"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update DS.SIM_FIS_DS
		set SIM_ETUDE_DS__ID = :new.ID  
		where SIM_ETUDE_DS__ID = :old.ID;
	end if;
	--  Modification du code du parent "DS.SIM_ETUDE_DS" dans les enfants "DS.SIM_DVP_DS"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update DS.SIM_DVP_DS
		set SIM_ETUDE_DS__ID = :new.ID  
		where SIM_ETUDE_DS__ID = :old.ID;
	end if;
	--  Modification du code du parent "DS.SIM_ETUDE_DS" dans les enfants "DS.SIM_REC_DS"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update DS.SIM_REC_DS
		set SIM_ETUDE_DS__ID = :new.ID  
		where SIM_ETUDE_DS__ID = :old.ID;
	end if;
	--  Modification du code du parent "DS.SIM_ETUDE_DS" dans les enfants "DS.SIM_ENTRETIEN_DS"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update DS.SIM_ENTRETIEN_DS
		set SIM_ETUDE_DS__ID = :new.ID  
		where SIM_ETUDE_DS__ID = :old.ID;
	end if;
	--  Modification du code du parent "DS.SIM_ETUDE_DS" dans les enfants "DS.SIM_CALCUL_DS"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update DS.SIM_CALCUL_DS
		set SIM_ETUDE_DS__ID = :new.ID  
		where SIM_ETUDE_DS__ID = :old.ID;
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


create or replace TRIGGER "DS"."TDA_SIMETUDEDS" after delete
on DS.SIM_ETUDE_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "DS.SIM_FIS_DS"
	delete DS.SIM_FIS_DS
	where SIM_ETUDE_DS__ID = :old.ID;
	
	--  Suppression des enfants dans "DS.SIM_DVP_DS"
	delete DS.SIM_DVP_DS
	where SIM_ETUDE_DS__ID = :old.ID;
	
	--  Suppression des enfants dans "DS.SIM_REC_DS"
	delete DS.SIM_REC_DS
	where SIM_ETUDE_DS__ID = :old.ID;
	
	--  Suppression des enfants dans "DS.SIM_ENTRETIEN_DS"
	delete DS.SIM_ENTRETIEN_DS
	where SIM_ETUDE_DS__ID = :old.ID;
	
	--  Suppression des enfants dans "DS.SIM_CALCUL_DS"
	delete DS.SIM_CALCUL_DS
	where SIM_ETUDE_DS__ID = :old.ID;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "DS"."TIB_SIMFISCLASSEDS" before insert
on DS.SIM_FIS_CLASSE_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.SIM_FIS_DS"
	cursor c1_sim_fis_classe_ds(Vsim_fis_ds__id number) is
		select 1 
		from DS.SIM_FIS_DS 
		where 
		ID = Vsim_fis_ds__id and Vsim_fis_ds__id is not null;
begin

	
	--  Le parent "DS.SIM_FIS_DS" doit exister à la création d'un enfant dans "DS.SIM_FIS_CLASSE_DS"
	if :new.SIM_FIS_DS__ID is not null then 
		open c1_sim_fis_classe_ds ( :new.SIM_FIS_DS__ID);
		fetch c1_sim_fis_classe_ds into dummy;
		found := c1_sim_fis_classe_ds%FOUND;
		close c1_sim_fis_classe_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_FIS_DS". Impossible de créer un enfant dans "DS.SIM_FIS_CLASSE_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUB_SIMFISCLASSEDS" before update
on DS.SIM_FIS_CLASSE_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.SIM_FIS_DS"
	cursor c1_sim_fis_classe_ds (Vsim_fis_ds__id number) is
		select 1 
		from DS.SIM_FIS_DS 
		where 
		ID = Vsim_fis_ds__id and Vsim_fis_ds__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "DS.SIM_FIS_DS" doit exister à la création d'un enfant dans "DS.SIM_FIS_CLASSE_DS"
	if :new.SIM_FIS_DS__ID is not null and seq = 0 then 
		open c1_sim_fis_classe_ds ( :new.SIM_FIS_DS__ID);
		fetch c1_sim_fis_classe_ds into dummy;
		found := c1_sim_fis_classe_ds%FOUND;
		close c1_sim_fis_classe_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_FIS_DS". Impossible de modifier un enfant dans "DS.SIM_FIS_CLASSE_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUA_SIMFISCLASSEDS" after update
of SIM_FIS_DS__ID,ID
on DS.SIM_FIS_CLASSE_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "DS.SIM_FIS_CLASSE_DS" dans les enfants "DS.SIM_FIS_VALUES_DS"
	if ((updating('SIM_FIS_DS__ID') and :old.SIM_FIS_DS__ID != :new.SIM_FIS_DS__ID) or 
	(updating('ID') and :old.ID != :new.ID)) then 
		update DS.SIM_FIS_VALUES_DS
		set SIM_FIS_DS__ID = :new.SIM_FIS_DS__ID,
		SIM_FIS_CLASSE_DS__ID = :new.ID  
		where SIM_FIS_DS__ID = :old.SIM_FIS_DS__ID and 
		SIM_FIS_CLASSE_DS__ID = :old.ID;
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


create or replace TRIGGER "DS"."TDA_SIMFISCLASSEDS" after delete
on DS.SIM_FIS_CLASSE_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "DS.SIM_FIS_VALUES_DS"
	delete DS.SIM_FIS_VALUES_DS
	where SIM_FIS_DS__ID = :old.SIM_FIS_DS__ID and 
	SIM_FIS_CLASSE_DS__ID = :old.ID;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "DS"."TIB_SIMFISDS" before insert
on DS.SIM_FIS_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.SIM_ETUDE_DS"
	cursor c1_sim_fis_ds(Vsim_etude_ds__id number) is
		select 1 
		from DS.SIM_ETUDE_DS 
		where 
		ID = Vsim_etude_ds__id and Vsim_etude_ds__id is not null;
begin

	
	--  Le parent "DS.SIM_ETUDE_DS" doit exister à la création d'un enfant dans "DS.SIM_FIS_DS"
	if :new.SIM_ETUDE_DS__ID is not null then 
		open c1_sim_fis_ds ( :new.SIM_ETUDE_DS__ID);
		fetch c1_sim_fis_ds into dummy;
		found := c1_sim_fis_ds%FOUND;
		close c1_sim_fis_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_ETUDE_DS". Impossible de créer un enfant dans "DS.SIM_FIS_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUB_SIMFISDS" before update
on DS.SIM_FIS_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.SIM_ETUDE_DS"
	cursor c1_sim_fis_ds (Vsim_etude_ds__id number) is
		select 1 
		from DS.SIM_ETUDE_DS 
		where 
		ID = Vsim_etude_ds__id and Vsim_etude_ds__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "DS.SIM_ETUDE_DS" doit exister à la création d'un enfant dans "DS.SIM_FIS_DS"
	if :new.SIM_ETUDE_DS__ID is not null and seq = 0 then 
		open c1_sim_fis_ds ( :new.SIM_ETUDE_DS__ID);
		fetch c1_sim_fis_ds into dummy;
		found := c1_sim_fis_ds%FOUND;
		close c1_sim_fis_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_ETUDE_DS". Impossible de modifier un enfant dans "DS.SIM_FIS_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUA_SIMFISDS" after update
of ID
on DS.SIM_FIS_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "DS.SIM_FIS_DS" dans les enfants "DS.SIM_FIS_CLASSE_DS"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update DS.SIM_FIS_CLASSE_DS
		set SIM_FIS_DS__ID = :new.ID  
		where SIM_FIS_DS__ID = :old.ID;
	end if;
	--  Modification du code du parent "DS.SIM_FIS_DS" dans les enfants "DS.SIM_CALCUL_FIS_DS"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update DS.SIM_CALCUL_FIS_DS
		set SIM_FIS_DS__ID = :new.ID  
		where SIM_FIS_DS__ID = :old.ID;
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


create or replace TRIGGER "DS"."TDA_SIMFISDS" after delete
on DS.SIM_FIS_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "DS.SIM_FIS_CLASSE_DS"
	delete DS.SIM_FIS_CLASSE_DS
	where SIM_FIS_DS__ID = :old.ID;
	
	--  Suppression des enfants dans "DS.SIM_CALCUL_FIS_DS"
	delete DS.SIM_CALCUL_FIS_DS
	where SIM_FIS_DS__ID = :old.ID;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "DS"."TIB_SIMFISVALUESDS" before insert
on DS.SIM_FIS_VALUES_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.SIM_FIS_CLASSE_DS"
	cursor c1_sim_fis_values_ds(Vsim_fis_ds__id number,
	Vsim_fis_classe_ds__id number) is
		select 1 
		from DS.SIM_FIS_CLASSE_DS 
		where 
		SIM_FIS_DS__ID = Vsim_fis_ds__id and Vsim_fis_ds__id is not null and 
		ID = Vsim_fis_classe_ds__id and Vsim_fis_classe_ds__id is not null;
begin

	
	--  Le parent "DS.SIM_FIS_CLASSE_DS" doit exister à la création d'un enfant dans "DS.SIM_FIS_VALUES_DS"
	if :new.SIM_FIS_DS__ID is not null and 
	:new.SIM_FIS_CLASSE_DS__ID is not null then 
		open c1_sim_fis_values_ds ( :new.SIM_FIS_DS__ID,
		:new.SIM_FIS_CLASSE_DS__ID);
		fetch c1_sim_fis_values_ds into dummy;
		found := c1_sim_fis_values_ds%FOUND;
		close c1_sim_fis_values_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_FIS_CLASSE_DS". Impossible de créer un enfant dans "DS.SIM_FIS_VALUES_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUB_SIMFISVALUESDS" before update
on DS.SIM_FIS_VALUES_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.SIM_FIS_CLASSE_DS"
	cursor c1_sim_fis_values_ds (Vsim_fis_ds__id number,
	Vsim_fis_classe_ds__id number) is
		select 1 
		from DS.SIM_FIS_CLASSE_DS 
		where 
		SIM_FIS_DS__ID = Vsim_fis_ds__id and Vsim_fis_ds__id is not null and 
		ID = Vsim_fis_classe_ds__id and Vsim_fis_classe_ds__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "DS.SIM_FIS_CLASSE_DS" doit exister à la création d'un enfant dans "DS.SIM_FIS_VALUES_DS"
	if :new.SIM_FIS_DS__ID is not null and seq = 0 and 
	:new.SIM_FIS_CLASSE_DS__ID is not null and seq = 0 then 
		open c1_sim_fis_values_ds ( :new.SIM_FIS_DS__ID,
		:new.SIM_FIS_CLASSE_DS__ID);
		fetch c1_sim_fis_values_ds into dummy;
		found := c1_sim_fis_values_ds%FOUND;
		close c1_sim_fis_values_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_FIS_CLASSE_DS". Impossible de modifier un enfant dans "DS.SIM_FIS_VALUES_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TIB_SIMRECDS" before insert
on DS.SIM_REC_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.SIM_ETUDE_DS"
	cursor c1_sim_rec_ds(Vsim_etude_ds__id number) is
		select 1 
		from DS.SIM_ETUDE_DS 
		where 
		ID = Vsim_etude_ds__id and Vsim_etude_ds__id is not null;
begin

	
	--  Le parent "DS.SIM_ETUDE_DS" doit exister à la création d'un enfant dans "DS.SIM_REC_DS"
	if :new.SIM_ETUDE_DS__ID is not null then 
		open c1_sim_rec_ds ( :new.SIM_ETUDE_DS__ID);
		fetch c1_sim_rec_ds into dummy;
		found := c1_sim_rec_ds%FOUND;
		close c1_sim_rec_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_ETUDE_DS". Impossible de créer un enfant dans "DS.SIM_REC_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUB_SIMRECDS" before update
on DS.SIM_REC_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.SIM_ETUDE_DS"
	cursor c1_sim_rec_ds (Vsim_etude_ds__id number) is
		select 1 
		from DS.SIM_ETUDE_DS 
		where 
		ID = Vsim_etude_ds__id and Vsim_etude_ds__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "DS.SIM_ETUDE_DS" doit exister à la création d'un enfant dans "DS.SIM_REC_DS"
	if :new.SIM_ETUDE_DS__ID is not null and seq = 0 then 
		open c1_sim_rec_ds ( :new.SIM_ETUDE_DS__ID);
		fetch c1_sim_rec_ds into dummy;
		found := c1_sim_rec_ds%FOUND;
		close c1_sim_rec_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_ETUDE_DS". Impossible de modifier un enfant dans "DS.SIM_REC_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUA_SIMRECDS" after update
of ID
on DS.SIM_REC_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "DS.SIM_REC_DS" dans les enfants "DS.SIM_CALCUL_TRAFIC_DS"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update DS.SIM_CALCUL_TRAFIC_DS
		set SIM_REC_DS__ID = :new.ID  
		where SIM_REC_DS__ID = :old.ID;
	end if;
	--  Modification du code du parent "DS.SIM_REC_DS" dans les enfants "DS.SIM_REC_VALUES_DS"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update DS.SIM_REC_VALUES_DS
		set SIM_REC_DS__ID = :new.ID  
		where SIM_REC_DS__ID = :old.ID;
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


create or replace TRIGGER "DS"."TDA_SIMRECDS" after delete
on DS.SIM_REC_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "DS.SIM_CALCUL_TRAFIC_DS"
	delete DS.SIM_CALCUL_TRAFIC_DS
	where SIM_REC_DS__ID = :old.ID;
	
	--  Suppression des enfants dans "DS.SIM_REC_VALUES_DS"
	delete DS.SIM_REC_VALUES_DS
	where SIM_REC_DS__ID = :old.ID;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "DS"."TIB_SIMRECVALUESDS" before insert
on DS.SIM_REC_VALUES_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.SIM_REC_DS"
	cursor c1_sim_rec_values_ds(Vsim_rec_ds__id number) is
		select 1 
		from DS.SIM_REC_DS 
		where 
		ID = Vsim_rec_ds__id and Vsim_rec_ds__id is not null;
begin

	
	--  Le parent "DS.SIM_REC_DS" doit exister à la création d'un enfant dans "DS.SIM_REC_VALUES_DS"
	if :new.SIM_REC_DS__ID is not null then 
		open c1_sim_rec_values_ds ( :new.SIM_REC_DS__ID);
		fetch c1_sim_rec_values_ds into dummy;
		found := c1_sim_rec_values_ds%FOUND;
		close c1_sim_rec_values_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_REC_DS". Impossible de créer un enfant dans "DS.SIM_REC_VALUES_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUB_SIMRECVALUESDS" before update
on DS.SIM_REC_VALUES_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.SIM_REC_DS"
	cursor c1_sim_rec_values_ds (Vsim_rec_ds__id number) is
		select 1 
		from DS.SIM_REC_DS 
		where 
		ID = Vsim_rec_ds__id and Vsim_rec_ds__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "DS.SIM_REC_DS" doit exister à la création d'un enfant dans "DS.SIM_REC_VALUES_DS"
	if :new.SIM_REC_DS__ID is not null and seq = 0 then 
		open c1_sim_rec_values_ds ( :new.SIM_REC_DS__ID);
		fetch c1_sim_rec_values_ds into dummy;
		found := c1_sim_rec_values_ds%FOUND;
		close c1_sim_rec_values_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_REC_DS". Impossible de modifier un enfant dans "DS.SIM_REC_VALUES_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TIB_SIMRESULTDS" before insert
on DS.SIM_RESULT_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.SIM_CALCUL_FIS_DS"
	cursor c1_sim_result_ds(Vsim_calcul_trafic_ds__id number,
	Vsim_fis_ds__id number) is
		select 1 
		from DS.SIM_CALCUL_FIS_DS 
		where 
		SIM_CALCUL_TRAFIC_DS__ID = Vsim_calcul_trafic_ds__id and Vsim_calcul_trafic_ds__id is not null and 
		SIM_FIS_DS__ID = Vsim_fis_ds__id and Vsim_fis_ds__id is not null;
begin

	
	--  Le parent "DS.SIM_CALCUL_FIS_DS" doit exister à la création d'un enfant dans "DS.SIM_RESULT_DS"
	if :new.SIM_CALCUL_TRAFIC_DS__ID is not null and 
	:new.SIM_FIS_DS__ID is not null then 
		open c1_sim_result_ds ( :new.SIM_CALCUL_TRAFIC_DS__ID,
		:new.SIM_FIS_DS__ID);
		fetch c1_sim_result_ds into dummy;
		found := c1_sim_result_ds%FOUND;
		close c1_sim_result_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_CALCUL_FIS_DS". Impossible de créer un enfant dans "DS.SIM_RESULT_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUB_SIMRESULTDS" before update
on DS.SIM_RESULT_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.SIM_CALCUL_FIS_DS"
	cursor c1_sim_result_ds (Vsim_calcul_trafic_ds__id number,
	Vsim_fis_ds__id number) is
		select 1 
		from DS.SIM_CALCUL_FIS_DS 
		where 
		SIM_CALCUL_TRAFIC_DS__ID = Vsim_calcul_trafic_ds__id and Vsim_calcul_trafic_ds__id is not null and 
		SIM_FIS_DS__ID = Vsim_fis_ds__id and Vsim_fis_ds__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "DS.SIM_CALCUL_FIS_DS" doit exister à la création d'un enfant dans "DS.SIM_RESULT_DS"
	if :new.SIM_CALCUL_TRAFIC_DS__ID is not null and seq = 0 and 
	:new.SIM_FIS_DS__ID is not null and seq = 0 then 
		open c1_sim_result_ds ( :new.SIM_CALCUL_TRAFIC_DS__ID,
		:new.SIM_FIS_DS__ID);
		fetch c1_sim_result_ds into dummy;
		found := c1_sim_result_ds%FOUND;
		close c1_sim_result_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.SIM_CALCUL_FIS_DS". Impossible de modifier un enfant dans "DS.SIM_RESULT_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUA_TREEDS" after update
of ID
on DS.TREE_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "DS.TREE_DS" dans les enfants "DS.NODE_DS"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update DS.NODE_DS
		set TREE_DS__ID = :new.ID  
		where TREE_DS__ID = :old.ID;
	end if;
	--  Modification du code du parent "DS.TREE_DS" dans les enfants "DS.TREE_RESULT_DS"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update DS.TREE_RESULT_DS
		set TREE_DS__ID = :new.ID  
		where TREE_DS__ID = :old.ID;
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


create or replace TRIGGER "DS"."TDA_TREEDS" after delete
on DS.TREE_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "DS.NODE_DS"
	delete DS.NODE_DS
	where TREE_DS__ID = :old.ID;
	
	--  Suppression des enfants dans "DS.TREE_RESULT_DS"
	delete DS.TREE_RESULT_DS
	where TREE_DS__ID = :old.ID;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "DS"."TIB_TREERESULTDS" before insert
on DS.TREE_RESULT_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.TREE_DS"
	cursor c1_tree_result_ds(Vtree_ds__id number) is
		select 1 
		from DS.TREE_DS 
		where 
		ID = Vtree_ds__id and Vtree_ds__id is not null;
begin

	
	--  Le parent "DS.TREE_DS" doit exister à la création d'un enfant dans "DS.TREE_RESULT_DS"
	if :new.TREE_DS__ID is not null then 
		open c1_tree_result_ds ( :new.TREE_DS__ID);
		fetch c1_tree_result_ds into dummy;
		found := c1_tree_result_ds%FOUND;
		close c1_tree_result_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.TREE_DS". Impossible de créer un enfant dans "DS.TREE_RESULT_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUB_TREERESULTDS" before update
on DS.TREE_RESULT_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.TREE_DS"
	cursor c1_tree_result_ds (Vtree_ds__id number) is
		select 1 
		from DS.TREE_DS 
		where 
		ID = Vtree_ds__id and Vtree_ds__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "DS.TREE_DS" doit exister à la création d'un enfant dans "DS.TREE_RESULT_DS"
	if :new.TREE_DS__ID is not null and seq = 0 then 
		open c1_tree_result_ds ( :new.TREE_DS__ID);
		fetch c1_tree_result_ds into dummy;
		found := c1_tree_result_ds%FOUND;
		close c1_tree_result_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.TREE_DS". Impossible de modifier un enfant dans "DS.TREE_RESULT_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUA_TREERESULTDS" after update
of TREE_DS__ID,ID
on DS.TREE_RESULT_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "DS.TREE_RESULT_DS" dans les enfants "DS.TREE_RESULT_PAVE_DS"
	if ((updating('TREE_DS__ID') and :old.TREE_DS__ID != :new.TREE_DS__ID) or 
	(updating('ID') and :old.ID != :new.ID)) then 
		update DS.TREE_RESULT_PAVE_DS
		set TREE_DS__ID = :new.TREE_DS__ID,
		TREE_RESULT_DS__ID = :new.ID  
		where TREE_DS__ID = :old.TREE_DS__ID and 
		TREE_RESULT_DS__ID = :old.ID;
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


create or replace TRIGGER "DS"."TDA_TREERESULTDS" after delete
on DS.TREE_RESULT_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "DS.TREE_RESULT_PAVE_DS"
	delete DS.TREE_RESULT_PAVE_DS
	where TREE_DS__ID = :old.TREE_DS__ID and 
	TREE_RESULT_DS__ID = :old.ID;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "DS"."TIB_TREERESULTPAVEDS" before insert
on DS.TREE_RESULT_PAVE_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.TREE_RESULT_DS"
	cursor c1_tree_result_pave_ds(Vtree_ds__id number,
	Vtree_result_ds__id number) is
		select 1 
		from DS.TREE_RESULT_DS 
		where 
		TREE_DS__ID = Vtree_ds__id and Vtree_ds__id is not null and 
		ID = Vtree_result_ds__id and Vtree_result_ds__id is not null;
begin

	
	--  Le parent "DS.TREE_RESULT_DS" doit exister à la création d'un enfant dans "DS.TREE_RESULT_PAVE_DS"
	if :new.TREE_DS__ID is not null and 
	:new.TREE_RESULT_DS__ID is not null then 
		open c1_tree_result_pave_ds ( :new.TREE_DS__ID,
		:new.TREE_RESULT_DS__ID);
		fetch c1_tree_result_pave_ds into dummy;
		found := c1_tree_result_pave_ds%FOUND;
		close c1_tree_result_pave_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.TREE_RESULT_DS". Impossible de créer un enfant dans "DS.TREE_RESULT_PAVE_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUB_TREERESULTPAVEDS" before update
on DS.TREE_RESULT_PAVE_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.TREE_RESULT_DS"
	cursor c1_tree_result_pave_ds (Vtree_ds__id number,
	Vtree_result_ds__id number) is
		select 1 
		from DS.TREE_RESULT_DS 
		where 
		TREE_DS__ID = Vtree_ds__id and Vtree_ds__id is not null and 
		ID = Vtree_result_ds__id and Vtree_result_ds__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "DS.TREE_RESULT_DS" doit exister à la création d'un enfant dans "DS.TREE_RESULT_PAVE_DS"
	if :new.TREE_DS__ID is not null and seq = 0 and 
	:new.TREE_RESULT_DS__ID is not null and seq = 0 then 
		open c1_tree_result_pave_ds ( :new.TREE_DS__ID,
		:new.TREE_RESULT_DS__ID);
		fetch c1_tree_result_pave_ds into dummy;
		found := c1_tree_result_pave_ds%FOUND;
		close c1_tree_result_pave_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.TREE_RESULT_DS". Impossible de modifier un enfant dans "DS.TREE_RESULT_PAVE_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUA_TREERESULTPAVEDS" after update
of TREE_DS__ID,TREE_RESULT_DS__ID,LIAISON,SENS,ABS_DEB
on DS.TREE_RESULT_PAVE_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "DS.TREE_RESULT_PAVE_DS" dans les enfants "DS.TREE_RESULT_PAVE_VOIE_DS"
	if ((updating('TREE_DS__ID') and :old.TREE_DS__ID != :new.TREE_DS__ID) or 
	(updating('TREE_RESULT_DS__ID') and :old.TREE_RESULT_DS__ID != :new.TREE_RESULT_DS__ID) or 
	(updating('LIAISON') and :old.LIAISON != :new.LIAISON) or 
	(updating('SENS') and :old.SENS != :new.SENS) or 
	(updating('ABS_DEB') and :old.ABS_DEB != :new.ABS_DEB)) then 
		update DS.TREE_RESULT_PAVE_VOIE_DS
		set TREE_DS__ID = :new.TREE_DS__ID,
		TREE_RESULT_DS__ID = :new.TREE_RESULT_DS__ID,
		TREE_RESULT_PAVE_DS__LIAISON = :new.LIAISON,
		TREE_RESULT_PAVE_DS__SENS = :new.SENS,
		TREE_RESULT_PAVE_DS__ABS_DEB = :new.ABS_DEB  
		where TREE_DS__ID = :old.TREE_DS__ID and 
		TREE_RESULT_DS__ID = :old.TREE_RESULT_DS__ID and 
		TREE_RESULT_PAVE_DS__LIAISON = :old.LIAISON and 
		TREE_RESULT_PAVE_DS__SENS = :old.SENS and 
		TREE_RESULT_PAVE_DS__ABS_DEB = :old.ABS_DEB;
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


create or replace TRIGGER "DS"."TDA_TREERESULTPAVEDS" after delete
on DS.TREE_RESULT_PAVE_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "DS.TREE_RESULT_PAVE_VOIE_DS"
	delete DS.TREE_RESULT_PAVE_VOIE_DS
	where TREE_DS__ID = :old.TREE_DS__ID and 
	TREE_RESULT_DS__ID = :old.TREE_RESULT_DS__ID and 
	TREE_RESULT_PAVE_DS__LIAISON = :old.LIAISON and 
	TREE_RESULT_PAVE_DS__SENS = :old.SENS and 
	TREE_RESULT_PAVE_DS__ABS_DEB = :old.ABS_DEB;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "DS"."TIB_TREERESULTPAVEVOIEDS" before insert
on DS.TREE_RESULT_PAVE_VOIE_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "DS.TREE_RESULT_PAVE_DS"
	cursor c1_tree_result_pave_voie_ds(Vtree_ds__id number,
	Vtree_result_ds__id number,
	Vtree_result_pave_ds__liaison varchar,
	Vtree_result_pave_ds__sens varchar,
	Vtree_result_pave_ds__abs_deb number) is
		select 1 
		from DS.TREE_RESULT_PAVE_DS 
		where 
		TREE_DS__ID = Vtree_ds__id and Vtree_ds__id is not null and 
		TREE_RESULT_DS__ID = Vtree_result_ds__id and Vtree_result_ds__id is not null and 
		LIAISON = Vtree_result_pave_ds__liaison and Vtree_result_pave_ds__liaison is not null and 
		SENS = Vtree_result_pave_ds__sens and Vtree_result_pave_ds__sens is not null and 
		ABS_DEB = Vtree_result_pave_ds__abs_deb and Vtree_result_pave_ds__abs_deb is not null;
begin

	
	--  Le parent "DS.TREE_RESULT_PAVE_DS" doit exister à la création d'un enfant dans "DS.TREE_RESULT_PAVE_VOIE_DS"
	if :new.TREE_DS__ID is not null and 
	:new.TREE_RESULT_DS__ID is not null and 
	:new.TREE_RESULT_PAVE_DS__LIAISON is not null and 
	:new.TREE_RESULT_PAVE_DS__SENS is not null and 
	:new.TREE_RESULT_PAVE_DS__ABS_DEB is not null then 
		open c1_tree_result_pave_voie_ds ( :new.TREE_DS__ID,
		:new.TREE_RESULT_DS__ID,
		:new.TREE_RESULT_PAVE_DS__LIAISON,
		:new.TREE_RESULT_PAVE_DS__SENS,
		:new.TREE_RESULT_PAVE_DS__ABS_DEB);
		fetch c1_tree_result_pave_voie_ds into dummy;
		found := c1_tree_result_pave_voie_ds%FOUND;
		close c1_tree_result_pave_voie_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.TREE_RESULT_PAVE_DS". Impossible de créer un enfant dans "DS.TREE_RESULT_PAVE_VOIE_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "DS"."TUB_TREERESULTPAVEVOIEDS" before update
on DS.TREE_RESULT_PAVE_VOIE_DS for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "DS.TREE_RESULT_PAVE_DS"
	cursor c1_tree_result_pave_voie_ds (Vtree_ds__id number,
	Vtree_result_ds__id number,
	Vtree_result_pave_ds__liaison varchar,
	Vtree_result_pave_ds__sens varchar,
	Vtree_result_pave_ds__abs_deb number) is
		select 1 
		from DS.TREE_RESULT_PAVE_DS 
		where 
		TREE_DS__ID = Vtree_ds__id and Vtree_ds__id is not null and 
		TREE_RESULT_DS__ID = Vtree_result_ds__id and Vtree_result_ds__id is not null and 
		LIAISON = Vtree_result_pave_ds__liaison and Vtree_result_pave_ds__liaison is not null and 
		SENS = Vtree_result_pave_ds__sens and Vtree_result_pave_ds__sens is not null and 
		ABS_DEB = Vtree_result_pave_ds__abs_deb and Vtree_result_pave_ds__abs_deb is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "DS.TREE_RESULT_PAVE_DS" doit exister à la création d'un enfant dans "DS.TREE_RESULT_PAVE_VOIE_DS"
	if :new.TREE_DS__ID is not null and seq = 0 and 
	:new.TREE_RESULT_DS__ID is not null and seq = 0 and 
	:new.TREE_RESULT_PAVE_DS__LIAISON is not null and seq = 0 and 
	:new.TREE_RESULT_PAVE_DS__SENS is not null and seq = 0 and 
	:new.TREE_RESULT_PAVE_DS__ABS_DEB is not null and seq = 0 then 
		open c1_tree_result_pave_voie_ds ( :new.TREE_DS__ID,
		:new.TREE_RESULT_DS__ID,
		:new.TREE_RESULT_PAVE_DS__LIAISON,
		:new.TREE_RESULT_PAVE_DS__SENS,
		:new.TREE_RESULT_PAVE_DS__ABS_DEB);
		fetch c1_tree_result_pave_voie_ds into dummy;
		found := c1_tree_result_pave_voie_ds%FOUND;
		close c1_tree_result_pave_voie_ds;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "DS.TREE_RESULT_PAVE_DS". Impossible de modifier un enfant dans "DS.TREE_RESULT_PAVE_VOIE_DS".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


