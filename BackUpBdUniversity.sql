PGDMP     %                     y         
   University    12.4    12.4 (    u           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            v           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            w           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            x           1262    49187 
   University    DATABASE     ?   CREATE DATABASE "University" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Russian_Russia.1251' LC_CTYPE = 'Russian_Russia.1251';
    DROP DATABASE "University";
                postgres    false            ?            1259    49188    graphik    TABLE     ?   CREATE TABLE public.graphik (
    groupid integer,
    datelesson date,
    timelesson time without time zone,
    namesubject character varying(30),
    teacherid integer,
    classroom character varying(30)
);
    DROP TABLE public.graphik;
       public         heap    postgres    false            ?            1259    49191    students    TABLE     ?  CREATE TABLE public.students (
    id integer NOT NULL,
    login character varying(30) NOT NULL,
    pass character varying(30) NOT NULL,
    firstname character varying(30),
    secondname character varying(30),
    lastname character varying(30),
    email character varying(30),
    telephone character varying(30),
    dateborn date,
    sex character varying(30),
    CONSTRAINT students_sex_check CHECK ((((sex)::text = 'Ж'::text) OR ((sex)::text = 'М'::text)))
);
    DROP TABLE public.students;
       public         heap    postgres    false            ?            1259    49195    studentsingroup    TABLE     T   CREATE TABLE public.studentsingroup (
    studentid integer,
    groupid integer
);
 #   DROP TABLE public.studentsingroup;
       public         heap    postgres    false            ?            1259    49198 	   studgroup    TABLE     ?   CREATE TABLE public.studgroup (
    id integer NOT NULL,
    numbergroup character varying(30) NOT NULL,
    cours integer,
    yearstart date,
    yearend date
);
    DROP TABLE public.studgroup;
       public         heap    postgres    false            ?            1259    49201    teacher    TABLE     ?  CREATE TABLE public.teacher (
    id integer NOT NULL,
    login character varying(30) NOT NULL,
    pass character varying(30) NOT NULL,
    firstname character varying(30),
    secondname character varying(30),
    lastname character varying(30),
    email character varying(30),
    telephone character varying(30),
    dateborn date,
    sex character varying(30),
    CONSTRAINT teacher_sex_check CHECK ((((sex)::text = 'Ж'::text) OR ((sex)::text = 'М'::text)))
);
    DROP TABLE public.teacher;
       public         heap    postgres    false            ?            1259    49205    tmp_val_for_grafik    TABLE     k   CREATE TABLE public.tmp_val_for_grafik (
    flt_name character varying(30) NOT NULL,
    flt_date date
);
 &   DROP TABLE public.tmp_val_for_grafik;
       public         heap    postgres    false            ?            1259    49208    graphik_views    VIEW     ?  CREATE VIEW public.graphik_views AS
 SELECT gf.timelesson,
    gf.namesubject,
    concat(tr.firstname, ' ', tr.secondname) AS teacher,
    gf.classroom
   FROM ((((public.students st
     JOIN public.studentsingroup stingp ON ((stingp.studentid = st.id)))
     JOIN public.studgroup stgp ON ((stgp.id = stingp.groupid)))
     JOIN public.graphik gf ON ((gf.groupid = stgp.id)))
     JOIN public.teacher tr ON ((tr.id = gf.teacherid)))
  WHERE (((st.login)::text = (( SELECT tmp_val_for_grafik.flt_name
           FROM public.tmp_val_for_grafik))::text) AND (gf.datelesson = ( SELECT tmp_val_for_grafik.flt_date
           FROM public.tmp_val_for_grafik)))
  ORDER BY gf.timelesson;
     DROP VIEW public.graphik_views;
       public          postgres    false    202    204    204    206    203    203    202    206    206    202    202    202    202    205    207    207            ?            1259    49213    students_id_seq    SEQUENCE     ?   ALTER TABLE public.students ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.students_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    203            ?            1259    49215    studgroup_id_seq    SEQUENCE     ?   ALTER TABLE public.studgroup ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.studgroup_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    205            ?            1259    49217    teacher_id_seq    SEQUENCE     ?   ALTER TABLE public.teacher ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.teacher_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    206            j          0    49188    graphik 
   TABLE DATA           e   COPY public.graphik (groupid, datelesson, timelesson, namesubject, teacherid, classroom) FROM stdin;
    public          postgres    false    202   ?3       k          0    49191    students 
   TABLE DATA           u   COPY public.students (id, login, pass, firstname, secondname, lastname, email, telephone, dateborn, sex) FROM stdin;
    public          postgres    false    203   ?4       l          0    49195    studentsingroup 
   TABLE DATA           =   COPY public.studentsingroup (studentid, groupid) FROM stdin;
    public          postgres    false    204   ?6       m          0    49198 	   studgroup 
   TABLE DATA           O   COPY public.studgroup (id, numbergroup, cours, yearstart, yearend) FROM stdin;
    public          postgres    false    205   ?6       n          0    49201    teacher 
   TABLE DATA           t   COPY public.teacher (id, login, pass, firstname, secondname, lastname, email, telephone, dateborn, sex) FROM stdin;
    public          postgres    false    206   7       o          0    49205    tmp_val_for_grafik 
   TABLE DATA           @   COPY public.tmp_val_for_grafik (flt_name, flt_date) FROM stdin;
    public          postgres    false    207   ?7       y           0    0    students_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.students_id_seq', 11, true);
          public          postgres    false    209            z           0    0    studgroup_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.studgroup_id_seq', 2, true);
          public          postgres    false    210            {           0    0    teacher_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.teacher_id_seq', 2, true);
          public          postgres    false    211            ?
           2606    49220 1   graphik graphik_datelesson_timelesson_groupid_key 
   CONSTRAINT     ?   ALTER TABLE ONLY public.graphik
    ADD CONSTRAINT graphik_datelesson_timelesson_groupid_key UNIQUE (datelesson, timelesson, groupid);
 [   ALTER TABLE ONLY public.graphik DROP CONSTRAINT graphik_datelesson_timelesson_groupid_key;
       public            postgres    false    202    202    202            ?
           2606    49222    students students_email_key 
   CONSTRAINT     W   ALTER TABLE ONLY public.students
    ADD CONSTRAINT students_email_key UNIQUE (email);
 E   ALTER TABLE ONLY public.students DROP CONSTRAINT students_email_key;
       public            postgres    false    203            ?
           2606    49224    students students_login_key 
   CONSTRAINT     W   ALTER TABLE ONLY public.students
    ADD CONSTRAINT students_login_key UNIQUE (login);
 E   ALTER TABLE ONLY public.students DROP CONSTRAINT students_login_key;
       public            postgres    false    203            ?
           2606    49226    students students_pk 
   CONSTRAINT     R   ALTER TABLE ONLY public.students
    ADD CONSTRAINT students_pk PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.students DROP CONSTRAINT students_pk;
       public            postgres    false    203            ?
           2606    49228    students students_telephone_key 
   CONSTRAINT     _   ALTER TABLE ONLY public.students
    ADD CONSTRAINT students_telephone_key UNIQUE (telephone);
 I   ALTER TABLE ONLY public.students DROP CONSTRAINT students_telephone_key;
       public            postgres    false    203            ?
           2606    49230 5   studentsingroup studentsingroup_studentid_groupid_key 
   CONSTRAINT     ~   ALTER TABLE ONLY public.studentsingroup
    ADD CONSTRAINT studentsingroup_studentid_groupid_key UNIQUE (studentid, groupid);
 _   ALTER TABLE ONLY public.studentsingroup DROP CONSTRAINT studentsingroup_studentid_groupid_key;
       public            postgres    false    204    204            ?
           2606    49232 #   studgroup studgroup_numbergroup_key 
   CONSTRAINT     e   ALTER TABLE ONLY public.studgroup
    ADD CONSTRAINT studgroup_numbergroup_key UNIQUE (numbergroup);
 M   ALTER TABLE ONLY public.studgroup DROP CONSTRAINT studgroup_numbergroup_key;
       public            postgres    false    205            ?
           2606    49234    studgroup studgroup_pk 
   CONSTRAINT     T   ALTER TABLE ONLY public.studgroup
    ADD CONSTRAINT studgroup_pk PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.studgroup DROP CONSTRAINT studgroup_pk;
       public            postgres    false    205            ?
           2606    49236    teacher teacher_email_key 
   CONSTRAINT     U   ALTER TABLE ONLY public.teacher
    ADD CONSTRAINT teacher_email_key UNIQUE (email);
 C   ALTER TABLE ONLY public.teacher DROP CONSTRAINT teacher_email_key;
       public            postgres    false    206            ?
           2606    49238    teacher teacher_login_key 
   CONSTRAINT     U   ALTER TABLE ONLY public.teacher
    ADD CONSTRAINT teacher_login_key UNIQUE (login);
 C   ALTER TABLE ONLY public.teacher DROP CONSTRAINT teacher_login_key;
       public            postgres    false    206            ?
           2606    49240    teacher teacher_pk 
   CONSTRAINT     P   ALTER TABLE ONLY public.teacher
    ADD CONSTRAINT teacher_pk PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.teacher DROP CONSTRAINT teacher_pk;
       public            postgres    false    206            ?
           2606    49242    teacher teacher_telephone_key 
   CONSTRAINT     ]   ALTER TABLE ONLY public.teacher
    ADD CONSTRAINT teacher_telephone_key UNIQUE (telephone);
 G   ALTER TABLE ONLY public.teacher DROP CONSTRAINT teacher_telephone_key;
       public            postgres    false    206            ?
           2606    49244 (   tmp_val_for_grafik tmp_val_for_grafik_pk 
   CONSTRAINT     l   ALTER TABLE ONLY public.tmp_val_for_grafik
    ADD CONSTRAINT tmp_val_for_grafik_pk PRIMARY KEY (flt_name);
 R   ALTER TABLE ONLY public.tmp_val_for_grafik DROP CONSTRAINT tmp_val_for_grafik_pk;
       public            postgres    false    207            ?
           2606    49245    graphik graphik_groupid_fkey    FK CONSTRAINT        ALTER TABLE ONLY public.graphik
    ADD CONSTRAINT graphik_groupid_fkey FOREIGN KEY (groupid) REFERENCES public.studgroup(id);
 F   ALTER TABLE ONLY public.graphik DROP CONSTRAINT graphik_groupid_fkey;
       public          postgres    false    2780    202    205            ?
           2606    49250    graphik graphik_teacherid_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public.graphik
    ADD CONSTRAINT graphik_teacherid_fkey FOREIGN KEY (teacherid) REFERENCES public.teacher(id);
 H   ALTER TABLE ONLY public.graphik DROP CONSTRAINT graphik_teacherid_fkey;
       public          postgres    false    202    2786    206            ?
           2606    49255    studentsingroup group_fk    FK CONSTRAINT     {   ALTER TABLE ONLY public.studentsingroup
    ADD CONSTRAINT group_fk FOREIGN KEY (groupid) REFERENCES public.studgroup(id);
 B   ALTER TABLE ONLY public.studentsingroup DROP CONSTRAINT group_fk;
       public          postgres    false    205    204    2780            ?
           2606    49260    studentsingroup students_fk    FK CONSTRAINT        ALTER TABLE ONLY public.studentsingroup
    ADD CONSTRAINT students_fk FOREIGN KEY (studentid) REFERENCES public.students(id);
 E   ALTER TABLE ONLY public.studentsingroup DROP CONSTRAINT students_fk;
       public          postgres    false    2772    204    203            j   ?   x???1?P?z?]0;?Ěcx%???W ?!??a?F,4?&??7?15̀?Tp<??>?yŞ??|?H??&???D?(?	???f?&e?v??&?0?cƵ9<?>?m???c??W~???ٟ?_)?	??Z>      k   ?  x?u?Ao?0??/????*??$[{?D
h?dU!h??ʢ?j?tm??;?]vA?	??*E_??a?eB?)/??l????O????G3????M??????~???~?.??W???? ;s?????:?[?²?PSYo??????EbO???۔??!?$?$ۀ_?l????E????&?G??D?s???'w?1????x+???R????X??X ~??_zX@G=?8
??B)5u m4?Kv ?6?yo$?Yn?$?Myz4֬?{5???V:??&n??????LUgr8?Eu^????+'J???`_?xJcͶmS???&u?M?C[?,)???Sg?bjwNk??Ժ?1?bŤ<??:ڐ?R??$?2͢?????rr?X????ɒ5?qL+??ieS?V??G_???*VJ?e4[I???_k,???????T??D?.????svﯨׁ??޲??_???`g???6Ցt??1[齵????;      l   "   x?3?4?2bcN#. ? bCa$b???? M?O      m   @   x?E??? C?s??#? Qv??s@?V??姸?	?؊
?i?zg??q*??>??]??]?? y??      n   ?   x?3??M??????e????FƜ?\?pa???;.?A?\?waӅ?19KR?3r3s??J9-45?X?8--LuLuM???8?sR??@???.쾰??f8a? g	??F@;??u??t???vXZ???p^?????? Ga?      o      x?K??+K?4202?54?52?????? =?r     