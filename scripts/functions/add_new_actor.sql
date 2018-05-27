CREATE OR REPLACE FUNCTION add_new_actor(fname character varying(45),lname character varying(45))
    RETURNS VOID AS
$$
BEGIN
    INSERT INTO actor (first_name,last_name) values(fname, lname);
END
$$
    LANGUAGE 'plpgsql';