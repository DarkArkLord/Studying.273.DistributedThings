CREATE TABLE TestTable (
	id INTEGER not null PRIMARY KEY,
	code varchar(100) not NULL
);

insert into testtable values (1, '123'), (2, 'test')

SELECT id, code
FROM public.testtable;