CREATE USER DS IDENTIFIED BY DS
DEFAULT TABLESPACE users
QUOTA UNLIMITED ON users
/

GRANT connect, schema_def TO DS
/ 
