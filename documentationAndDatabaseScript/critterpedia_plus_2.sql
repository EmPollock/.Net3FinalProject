/* check whether database exists, and if so, drop it */
IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases
		  WHERE name = 'critterpedia_plus')
BEGIN
	DROP DATABASE critterpedia_plus
	print '' print '*** dropping database critterpedia_plus ***'
END
GO

print '' print '*** creating database critterpedia_plus'
GO
CREATE DATABASE critterpedia_plus
GO

print '' print '*** using database critterpedia_plus'
GO
USE [critterpedia_plus]
GO

/*
	Creates fish_locations table
*/
print '' print '*** creating fish_location table ***'
CREATE TABLE [dbo].[fish_location] (
	[location_id]			[nvarchar](40) 		NOT NULL, 
    [location_description] 	[nvarchar](170) 	NOT NULL,
    CONSTRAINT [pk_location_id] PRIMARY KEY([location_id])
)
GO

/*
	fish_location test records
*/
print '' print '*** creating fish_location test records ***'
INSERT INTO [dbo].[fish_location]
		([location_id], [location_description])
	VALUES
		('River', 'The long bodies of water in the inland part of the island.'),
		('Pond', 'The smaller bodies of water in the inland part of the island.'),
		('River (clifftop)', 'Any river that is on a higher level than the base level. Requires a ladder or incline to access.'), 
		('River (mouth)', 'The water where a river meets the sea.'),
		('Sea', 'The water bordering the island.'), 
		('Pier', 'The water off the prexisting pier that can be on either the east or west side of the island.')
GO


/*
	Creates bug_finding_spots table
*/
print '' print '*** bug_finding_spot table ***'
CREATE TABLE [dbo].[bug_finding_spot](
	spot_id 				[nvarchar](40) 		NOT NULL,
    spot_description 		[nvarchar](170) 	NOT NULL,
    CONSTRAINT [pk_spot_id] PRIMARY KEY ([spot_id])
)
GO

/*
	bug_finding_spot test records
*/
print '' print '*** creating bug_finding_spot test records ***'
INSERT INTO [dbo].[bug_finding_spot]
		([spot_id], [spot_description])
	VALUES
		('Flying', 'Found in the air anywhere around the island.'),
		('Flying by Hybrid Flowers', 'Found in the air near hybrid flowers (Flowers with colors that come from flower breeding).'),
		('Flying by purple flowers', 'Found in the air near purple flowers.'),
		('Flying by light', 'Found flying near light sources on furniture or on buildings'), 
		('On trees', 'Found on the trunk of any type of tree.'), 
		('On the ground', 'Found crawling on the ground anywhere around the island.'), 
		('On flowers', 'Found crawling on any type of flower.'),
		('On flowers (white)', 'Found crawling on any white flowers.'),
		('Shaken from trees', 'Found by shaking trees. (Sometimes hanging, sometimes flying)'),
		('Underground', 'Found by digging the ground with a shovel.'),
		('On ponds and rivers', 'Found floating on the water of ponds or rivers.'),
		('On tree stumps', 'Found on stumps of cut down trees.'),
		('On trees (Coconut)', 'Found on the trunks of coconut trees.'),
		('On the ground (Rolling Snowballs)', 'Found on the ground near snowballs, rolling them around.'),
		('Under trees disguised as leaves', 'Found under trees, appearing to be furniture leaves.'),
		('On rotten food','Found by leaving out turnips until they rot.'),
		('On the beach disguised as shells', 'Found on beach sand disguised as conch shells that occasionally shake.'),
		('On beach rocks', 'Found on the rocky areas of beaches.'),
		('On trash items', 'Found by dropping trash items (boots, tires, or empty cans).'),
		('On villagers', 'Found by looking for a dark bouncing speck on villagers.'),
		('On rocks or bushes', 'Found on rocks or flower bushes.'),
		('Under rocks', 'Found crawling on the ground after hitting rocks.')
GO

/*
	Creates critter_type table
*/
print '' print '*** creating critter_type table ***'
CREATE TABLE [dbo].[critter_type](
	critter_type_id	 		[nvarchar](40)		NOT NULL,
    catch_description 		[nvarchar](170)		NOT NULL,
    CONSTRAINT [pk_critter_type_id] PRIMARY KEY ([critter_type_id])
)
GO

/*
	critter_type test records 
*/
print '' print '*** creating critter_type test records ***'

INSERT INTO [dbo].[critter_type]
		([critter_type_id], [catch_description])
	VALUES
		('fish', 'While holding a fishing rod, stand in front of the water and press  ''A'' to cast a line. Aim to cast in front of a fish''s shadow.'),
		('bug', 'While holding a net, hold down the ''A'' button and release it when the bug is infront of you.'),
		('sea creature', 'Wear a swimsuit to swim in the sea and use the ''Y'' button to dive on top of shadows.')
GO

/*
	Creates role table
*/
print '' print '*** creating role table ***'
CREATE TABLE [dbo].[role](
	role_id 				[nvarchar](40) 		NOT NULL,
    role_description 		[nvarchar](170) 	NOT NULL,
    CONSTRAINT [pk_role_id] PRIMARY KEY ([role_id])
)
GO

/*
	role test records
*/
print '' print '*** creating role test records ***'
INSERT INTO [dbo].[role]
		([role_id], role_description)
 	VALUES
		('Villager', 'Can put critters in the museum, look at all users'' critterpedias, update their own critterpedia, look at information about all critters'),
		('Island Owner', 'Can correct mistakes in critter information, add critters, remove critters, remove users except themself, chang users'' roles except their own.'),
		('Museum Admin', 'Can correct mistakes in whether critters are in the museum')
GO

/*
	Creates villager table
	
	Old default password: 
	'9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E',
*/
print '' print '*** creating villager table ***'
CREATE TABLE [dbo].[villager](
	villager_id				[int] Identity(100000, 1)	NOT NULL,
	login_name 				[nvarchar](16) UNIQUE		NOT NULL,
	email_address			[nvarchar](250)				NOT NULL,
    character_name 			[nvarchar](20) 				NOT NULL,
    password_hash 			[char](64) 					NOT NULL	default 
		'B03DDF3CA2E714A6548E7495E2A03F5E824EAAC9837CD7F159C67B90FB4B7342',	
    active						[bit]				NOT NULL  	default 1,
    CONSTRAINT [pk_villager_id] PRIMARY KEY ([villager_id])
) 
GO

/*
	villager test records
*/
print '' print '*** creating villager test records ***'
INSERT INTO [dbo].[villager]
		([character_name], [login_name], [email_address])
 	Values
		('Oomoo', 'MarshMelon', '20emmapoll@gmail.com'),
		('Nolan', 'NooterDooter', 'nolieman108@gmail.com'),
		('Avery', 'TheArtSojourner', 'gabd@gmail.com'),
		('Joey', 'YojeeBear', 'foreveryoung@gmail.com'),
		('Adamin', 'Admin', 'admin@company.com')
GO

/*
	Creates villager_role table
*/
print '' print '*** creating villager_role table ***'
CREATE TABLE [dbo].[villager_role](
		villager_id			[int]				NOT NULL,
		role_id				[nvarchar](40)		NOT NULL
		CONSTRAINT [pk_villager_id_role_id] PRIMARY KEY ([villager_id], [role_id]),
		CONSTRAINT [fk_villager_id_villager_role] FOREIGN KEY ([villager_id])
			REFERENCES [dbo].[villager]([villager_id]),
		CONSTRAINT [fk_role_role_id_villager_role] FOREIGN KEY ([role_id])
			REFERENCES [dbo].[role]([role_id])
)
GO

/*
	villager_role test records
*/
print '' print '*** creating villager_role test records ***'
INSERT INTO [dbo].[villager_role]
		([villager_id], [role_id])
	VALUES
		('100000', 'Villager'),
		('100000', 'Island Owner'),
		('100001', 'Villager'),
		('100001', 'Museum Admin'),
		('100002', 'Villager'),
		('100003', 'Villager'),
		('100004', 'Island Owner')
GO

/*
	Creates critterpedia table
*/
print '' print '*** creating critter table ***'
CREATE TABLE [dbo].[critter](
	critter_id		 		[nvarchar](40) 		NOT NULL,
    rain_needed 			[bit]				NOT NULL 	DEFAULT 0,
	is_in_museum 			[bit] 				NOT NULL 	DEFAULT 0,
    price 					[int] 				NOT NULL, 
    critter_type_id 		[nvarchar](40) 		NOT NULL,
	museum_by_login_name	[nvarchar](16)		NULL,		
	active					[bit]				NOT NULL	DEFAULT 1,
	CONSTRAINT [pk_critter_id] PRIMARY KEY([critter_id]),
	CONSTRAINT [fk_critter_type_critter_type_id] FOREIGN KEY([critter_type_id]) 
				REFERENCES [dbo].[critter_type]([critter_type_id]),
	CONSTRAINT [fk_museum_by_villager] FOREIGN KEY ([museum_by_login_name])
		REFERENCES [dbo].[villager]([login_name])
)
GO

/*
	critter test records 
*/
print '' print '*** creating critter test records ***'
INSERT INTO [dbo].[critter]
		([critter_id], [rain_needed], [is_in_museum], [price], [critter_type_id], [museum_by_login_name])
	VALUES
		('Bitterling', 0, 0, 900, 'fish', NULL),
		('Pale chub', 0, 0, 200, 'fish', NULL),
		('Crucian carp', 0, 0, 160, 'fish', NULL),
		('Dace', 0, 0, 240, 'fish', NULL),
		('Carp', 0, 0, 300, 'fish', NULL),
		('Koi', 0, 0, 4000, 'fish', NULL),
		('Goldfish', 0, 0, 1300, 'fish', NULL),
		('Pop-eyed goldfish', 0, 0, 1300, 'fish', NULL),
		('Ranchu goldfish', 0, 0, 4500, 'fish', NULL),
		('Killifish', 0, 0, 300, 'fish', NULL),
		('Crawfish', 0, 1, 200, 'fish', 'MarshMelon'),
		('Soft-shelled turtle', 0, 0, 3650, 'fish', NULL),
		('Snapping turtle', 0, 0, 5000, 'fish', NULL),
		('Tadpole', 0, 0, 100, 'fish', NULL),
		('Frog', 0, 0, 120, 'fish', NULL),
		('Freshwater goby', 0, 0, 400, 'fish', NULL),
		('Loach', 0, 0, 400, 'fish', NULL),
		('Catfish', 0, 1, 800, 'fish', 'YojeeBear'),
		('Giant snakehead', 0, 0, 5500, 'fish', NULL),
		('Bluegill', 0, 0, 180, 'fish', NULL),
		('Yellow perch', 0, 1, 300, 'fish', 'NooterDooter'),
		('Black bass', 0, 0, 400, 'fish', NULL),
		('Tilapia', 0, 0, 800, 'fish', NULL),
		('Pike', 0, 0, 1800, 'fish', NULL),
		('Pond smelt', 0, 0, 500, 'fish', NULL),
		('Sweetfish', 0, 0, 900, 'fish', NULL),
		('Cherry salmon', 0, 0, 1000, 'fish', NULL),
		('Char', 0, 0, 3800, 'fish', NULL),
		('Golden trout', 0, 1, 15000, 'fish', 'TheArtSojourner'),
		('Stringfish', 0, 0, 15000, 'fish', NULL),
		('Salmon', 0, 0, 700, 'fish', NULL),
		('King salmon', 0, 0, 1800, 'fish', NULL),
		('Mitten crab', 0, 0, 2000, 'fish', NULL),
		('Guppy', 0, 0, 1300, 'fish', NULL),
		('Nibble fish', 0, 0, 1500, 'fish', NULL),
		('Angelfish', 0, 0, 3000, 'fish', NULL),
		('Betta', 0, 0, 2500, 'fish', NULL),
		('Neon tetra', 0, 0, 500, 'fish', NULL),
		('Rainbowfish', 0, 1, 800, 'fish', 'YojeeBear'),
		('Piranha', 0, 0, 2500, 'fish', NULL),
		('Arowana', 0, 0, 10000, 'fish', NULL),
		('Dorado', 0, 1, 15000, 'fish', 'MarshMelon'),
		('Gar', 0, 0, 6000, 'fish', NULL),
		('Arapaima', 0, 1, 10000, 'fish', 'YojeeBear'),
		('Saddled bichir', 0, 0, 4000, 'fish', NULL),
		('Sturgeon', 0, 1, 10000, 'fish', 'NooterDooter'),
		('Sea butterfly', 0, 1, 1000, 'fish', 'TheArtSojourner'),
		('Sea horse', 0, 1, 1100, 'fish', 'YojeeBear'),
		('Clown fish', 0, 0, 650, 'fish', NULL),
		('Surgeonfish', 0, 0, 1000, 'fish', NULL),
		('Butterfly fish', 0, 0, 1000, 'fish', NULL),
		('Napoleonfish', 0, 0, 10000, 'fish', NULL),
		('Zebra turkeyfish', 0, 0, 500, 'fish', NULL),
		('Blowfish', 0, 0, 5000, 'fish', NULL),
		('Puffer fish', 0, 0, 250, 'fish', NULL),
		('Anchovy', 0, 0, 200, 'fish', NULL),
		('Horse mackerel', 0, 1, 150, 'fish', 'MarshMelon'),
		('Barred knifejaw', 0, 0, 5000, 'fish', NULL),
		('Sea bass', 0, 0, 400, 'fish', NULL),
		('Red snapper', 0, 0, 3000, 'fish', NULL),
		('Dab', 0, 1, 300, 'fish', 'YojeeBear'),
		('Olive flounder', 0, 0, 800, 'fish', NULL),
		('Squid', 0, 0, 500, 'fish', NULL),
		('Moray eel', 0, 0, 2000, 'fish', NULL),
		('Ribbon eel', 0, 0, 600, 'fish', NULL),
		('Tuna', 0, 1, 7000, 'fish', 'YojeeBear'),
		('Blue marlin', 0, 0, 10000, 'fish', NULL),
		('Giant trevally', 0, 1, 4500, 'fish', 'MarshMelon'),
		('Mahi-mahi', 0, 0, 6000, 'fish', NULL),
		('Ocean sunfish', 0, 1, 4000, 'fish', 'NooterDooter'),
		('Ray', 0, 0, 3000, 'fish', NULL),
		('Saw shark', 0, 1, 12000, 'fish', 'TheArtSojourner'),
		('Hammerhead shark', 0, 0, 8000, 'fish', NULL),
		('Great white shark', 0, 1, 15000, 'fish', 'TheArtSojourner'),
		('Whale shark', 0, 0, 13000, 'fish', NULL),
		('Suckerfish', 0, 0, 1500, 'fish', NULL),
		('Football fish', 0, 0, 2500, 'fish', NULL),
		('Oarfish', 0, 0, 9000, 'fish', NULL),
		('Barreleye', 0, 0, 15000, 'fish', NULL),
		('Coelacanth', 1, 1, 15000, 'fish', 'YojeeBear'),
		('Common butterfly', 0, 0, 160, 'bug', NULL),
		('Yellow butterfly', 0, 0, 160, 'bug', NULL),
		('Tiger butterfly', 0, 1, 240, 'bug', 'MarshMelon'),
		('Peacock butterfly', 0, 0, 2500, 'bug', NULL),
		('Common bluebottle', 0, 0, 300, 'bug', NULL),
		('Paper kite butterfly', 0, 0, 1000, 'bug', NULL),
		('Great purple emperor', 0, 0, 3000, 'bug', NULL),    
		('Monarch butterfly', 0, 0, 140, 'bug', NULL),
		('Emperor butterfly', 0, 1, 4000, 'bug', 'NooterDooter'),
		('Agrias butterfly', 0, 0, 3000, 'bug', NULL),
		('Rajah Brooke''s birdwing', 0, 0, 2500, 'bug', NULL),
		('Queen Alexandra''s birdwing', 0, 0, 4000, 'bug', NULL),
		('Moth', 0, 0, 130, 'bug', NULL),
		('Atlas moth', 0, 0, 3000, 'bug', NULL),
		('Madagascan sunset moth', 0, 1, 2500, 'bug', 'TheArtSojourner'),
		('Long locust', 0, 1, 200, 'bug', 'TheArtSojourner'),
		('Migratory locust', 0, 0, 600, 'bug', NULL),
		('Rice grasshopper', 0, 0, 160, 'bug', NULL),
		('Grasshopper', 0, 0, 160, 'bug', NULL),
		('Cricket', 0, 1, 130, 'bug', 'MarshMelon'),
		('Bell cricket', 0, 0, 430, 'bug', NULL),
		('Mantis', 0, 0, 430, 'bug', NULL),
		('Orchid mantis', 0, 0, 2400, 'bug', NULL),
		('Honeybee', 0, 0, 200, 'bug', NULL),
		('Wasp', 0, 0, 2500, 'bug', NULL),
		('Brown cicada', 0, 0, 250, 'bug', NULL),
		('Robust cicada', 0, 0, 300, 'bug', NULL),
		('Giant cicada', 0, 0, 500, 'bug', NULL),
		('Walker cicada', 0, 0, 400, 'bug', NULL),
		('Evening cicada', 0, 0, 550, 'bug', NULL),
		('Cicada shell', 0, 0, 10, 'bug', NULL),
		('Red dragonfly', 0, 0, 180, 'bug', NULL),
		('Darner dragonfly', 0, 0, 230, 'bug', NULL),
		('Banded dragonfly', 0, 0, 4500, 'bug', NULL),
		('Damselfly', 0, 0, 500, 'bug', NULL),
		('Firefly', 0, 1, 300, 'bug', 'NooterDooter'),
		('Mole cricket', 0, 0, 500, 'bug', NULL),
		('Pondskater', 0, 0, 130, 'bug', NULL),
		('Diving beetle', 0, 0, 800, 'bug', NULL),
		('Giant water bug', 0, 0, 2000, 'bug', NULL),
		('Stinkbug', 0, 0, 120, 'bug', NULL),
		('Man-faced stink bug', 0, 0, 1000, 'bug', NULL),
		('Ladybug', 0, 0, 200, 'bug', NULL),
		('Tiger beetle', 0, 0, 1500, 'bug', NULL),
		('Jewel beetle', 0, 0, 2400, 'bug', NULL),
		('Violin beetle', 0, 0, 450, 'bug', NULL),
		('Citrus long-horned beetle', 0, 0, 350, 'bug', NULL),
		('Rosalia batesi beetle', 0, 0, 3000, 'bug', NULL),
		('Blue weevil beetle', 0, 0, 800, 'bug', NULL),
		('Dung beetle', 0, 0, 3000, 'bug', NULL),
		('Earth-boring dung beetle', 0, 1, 300, 'bug', 'YojeeBear'),
		('Scarab beetle', 0, 0, 10000, 'bug', NULL),
		('Drone beetle', 0, 0, 200, 'bug', NULL),
		('Goliath beetle', 0, 1, 8000, 'bug', 'MarshMelon'),
		('Saw stag', 0, 0, 2000, 'bug', NULL),
		('Miyama stag', 0, 1, 1000, 'bug', 'NooterDooter'),
		('Giant stag', 0, 0, 10000, 'bug', NULL),
		('Rainbow stag', 0, 0, 6000, 'bug', NULL),
		('Cyclommatus stag', 0, 0, 8000, 'bug', NULL),
		('Golden stag', 0, 0, 12000, 'bug', NULL),
		('Giraffe stag', 0, 1, 12000, 'bug', 'TheArtSojourner'),
		('Horned dynastid', 0, 0, 1350, 'bug', NULL),
		('Horned atlas', 0, 0, 8000, 'bug', NULL),
		('Horned elephant', 0, 0, 8000, 'bug', NULL),
		('Horned hercules', 0, 0, 12000, 'bug', NULL),
		('Walking stick', 0, 0, 600, 'bug', NULL),
		('Walking leaf', 0, 0, 600, 'bug', NULL),
		('Bagworm', 0, 1, 600, 'bug', 'MarshMelon'),
		('Ant', 0, 0, 80, 'bug', NULL),
		('Hermit crab', 0, 1, 1000, 'bug', 'YojeeBear'),
		('Wharf roach', 0, 0, 200, 'bug', NULL),
		('Fly', 0, 0, 60, 'bug', NULL),
		('Mosquito', 0, 0, 130, 'bug', NULL),
		('Flea', 0, 0, 70, 'bug', NULL),
		('Snail', 1, 1, 250, 'bug', 'TheArtSojourner'),
		('Pill bug', 0, 0, 250, 'bug', NULL),
		('Centipede', 0, 1, 300, 'bug', 'NooterDooter'),
		('Spider', 0, 0, 600, 'bug', NULL),
		('Tarantula', 0, 0, 8000, 'bug', NULL),
		('Scorpion', 0, 0, 8000, 'bug', NULL),
		('Seaweed', 0, 0, 600, 'sea creature', NULL),
		('Sea grapes', 0, 0, 900, 'sea creature', NULL),
		('Sea cucumber', 0, 1, 500, 'sea creature', 'YojeeBear'),
		('Sea pig', 0, 0, 10000, 'sea creature', NULL),
		('Sea star', 0, 0, 500, 'sea creature', NULL),
		('Sea urchin', 0, 1, 1700, 'sea creature', 'MarshMelon'),
		('Slate pencil urchin', 0, 0, 2000, 'sea creature', NULL),
		('Sea anemone', 0, 0, 500, 'sea creature', NULL),
		('Moon jellyfish', 0, 0, 600, 'sea creature', NULL),
		('Sea slug', 0, 0, 600, 'sea creature', NULL),
		('Pearl oyster', 0, 0, 2800, 'sea creature', NULL),
		('Mussel', 0, 0, 1500, 'sea creature', NULL),
		('Oyster', 0, 0, 1100, 'sea creature', NULL),
		('Scallop', 0, 0, 1200, 'sea creature', NULL),
		('Whelk', 0, 0, 1000, 'sea creature', NULL),
		('Turban shell', 0, 0, 1000, 'sea creature', NULL),
		('Abalone', 0, 1, 2000, 'sea creature', 'TheArtSojourner'),
		('Gigas giant clam', 0, 1, 15000, 'sea creature', NULL),
		('Chambered nautilus', 0, 0, 1800, 'sea creature', NULL),
		('Octopus', 0, 0, 1200, 'sea creature', NULL),
		('Umbrella octopus', 0, 1, 6000, 'sea creature', 'NooterDooter'),
		('Vampire squid', 0, 1, 10000, 'sea creature', 'YojeeBear'),
		('Firefly squid', 0, 0, 1400, 'sea creature', NULL),
		('Gazami crab', 0, 0, 2200, 'sea creature', NULL),
		('Dungeoness crab', 0, 0, 1900, 'sea creature', NULL),
		('Snow crab', 0, 1, 6000, 'sea creature', 'MarshMelon'),
		('Red king crab', 0, 1, 8000, 'sea creature', 'TheArtSojourner'),
		('Acorn barnacle', 0, 1, 600, 'sea creature', 'TheArtSojourner'),
		('Spider crab', 0, 0, 12000, 'sea creature', NULL),
		('Tiger prawn', 0, 0, 3000, 'sea creature', NULL),
		('Sweet shrimp', 0, 0, 1400, 'sea creature', NULL),
		('Mantis shrimp', 0, 0, 2500, 'sea creature', NULL),
		('Spiny lobster', 0, 0, 5000, 'sea creature', NULL),
		('Lobster', 0, 0, 4500, 'sea creature', NULL),
		('Giant isopod', 0, 0, 12000, 'sea creature', NULL),
		('Horseshoe crab', 0, 1, 2500, 'sea creature', 'YojeeBear'),
		('Sea pineapple', 0, 1, 1500, 'sea creature', 'NooterDooter'),
		('Spotted garden eel', 0, 0, 1100, 'sea creature', NULL),
		('Flatworm', 0, 0, 700, 'sea creature', NULL),
		('Venus'' flower basket', 0, 0, 5000, 'sea creature', NULL)
GO

/*
	Creates date_range table
*/
print '' print '*** creating catchable_month table ***'
CREATE TABLE [dbo].[catchable_month](
	[critter_id] 			[nvarchar](40) 		NOT NULL, 
    [jan] 					[bit]	 			NOT NULL,
	[feb] 					[bit]	 			NOT NULL,
	[mar] 					[bit]	 			NOT NULL,
	[apr] 					[bit]	 			NOT NULL,
	[may] 					[bit]	 			NOT NULL,
	[june] 					[bit]	 			NOT NULL,
	[july] 					[bit]	 			NOT NULL,
	[aug] 					[bit]	 			NOT NULL,
	[sep] 					[bit]	 			NOT NULL,
	[octo] 					[bit]	 			NOT NULL,
	[nov] 					[bit]	 			NOT NULL,
	[dec] 					[bit]	 			NOT NULL,
    CONSTRAINT [pk_critter_id_catchable_month] PRIMARY KEY ([critter_id]),
    CONSTRAINT [fk_critter_critter_id_catchable_month] FOREIGN KEY ([critter_id])
        REFERENCES [dbo].[critter]([critter_id])
) 
GO

/*
	date_range test records
*/
print '' print '*** creating catchable_month test records ***'
INSERT INTO [dbo].[catchable_month]
		([critter_id],[jan],[feb],[mar],[apr],[may],[june],[july],[aug],[sep],[octo],[nov],[dec])
	VALUES
		('Bitterling', 1,1,1,0,0,0,0,0,0,0,1,1),
		('Pale chub', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Crucian Carp', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Dace', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Carp', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Koi', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Goldfish', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Pop-eyed goldfish', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Ranchu goldfish', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Killifish', 0,0,0,1,1,1,1,1,0,0,0,0),
		('Crawfish', 0,0,0,1,1,1,1,1,1,0,0,0),
		('Soft-shelled turtle', 0,0,0,0,0,0,0,1,1,0,0,0),
		('Snapping turtle', 0,0,0,1,1,1,1,1,1,1,0,0),
		('Tadpole', 0,0,1,1,1,1,1,0,0,0,0,0),
		('Frog', 0,0,0,0,1,1,1,1,0,0,0,0),
		('Freshwater goby', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Loach', 0,0,1,1,1,0,0,0,0,0,0,0),
		('Catfish', 0,0,0,0,1,1,1,1,1,1,0,0),
		('Giant Snakehead', 0,0,0,0,0,1,1,1,0,0,0,0),
		('Bluegill', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Yellow perch', 1,1,1,0,0,0,0,0,0,1,1,1),
		('Black bass', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Tilapia', 0,0,0,0,0,1,1,1,1,1,0,0),
		('Pike', 0,0,0,0,0,0,0,0,1,1,1,1),
		('Pond smelt', 1,1,0,0,0,0,0,0,0,0,0,1),
		('Sweetfish', 0,0,0,0,0,0,1,1,1,0,0,0),
		('Cherry salmon', 0,0,1,1,1,1,0,0,1,1,1,0),
		('Char', 0,0,1,1,1,1,0,0,1,1,1,0),
		('Golden trout', 0,0,1,1,1,0,0,0,1,1,1,0),
		('Stringfish', 1,1,1,0,0,0,0,0,0,0,0,1),
		('Salmon', 0,0,0,0,0,0,0,0,1,0,0,0),
		('King salmon', 0,0,0,0,0,0,0,0,1,0,0,0),
		('Mitten crab', 0,0,0,0,0,0,0,0,1,1,1,0),
		('Guppy', 0,0,0,1,1,1,1,1,1,1,1,0),
		('Nibble fish', 0,0,0,0,1,1,1,1,1,0,0,0),
		('Angelfish', 0,0,0,0,1,1,1,1,1,1,0,0),
		('Betta', 0,0,0,0,1,1,1,1,1,1,0,0),
		('Neon tetra', 0,0,0,1,1,1,1,1,1,1,1,0),
		('Rainbowfish', 0,0,0,0,1,1,1,1,1,1,0,0),
		('Piranha', 0,0,0,0,0,1,1,1,1,0,0,0),
		('Arowana', 0,0,0,0,0,1,1,1,1,0,0,0),
		('Dorado', 0,0,0,0,0,1,1,1,1,0,0,0),
		('Gar', 0,0,0,0,0,1,1,1,1,0,0,0),
		('Arapaima', 0,0,0,0,0,1,1,1,1,0,0,0),
		('Saddled Bichir', 0,0,0,0,0,1,1,1,1,0,0,0),
		('Sturgeon', 1,1,1,0,0,0,0,0,1,1,1,1),
		('Sea butterfly', 1,1,1,0,0,0,0,0,0,0,0,1),
		('Sea horse', 0,0,0,1,1,1,1,1,1,1,1,0),
		('Clown fish', 0,0,0,1,1,1,1,1,1,0,0,0),
		('Surgeonfish', 0,0,0,1,1,1,1,1,1,0,0,0),
		('Butterfly fish', 0,0,0,1,1,1,1,1,1,0,0,0),
		('Napoleonfish', 0,0,0,0,0,0,1,1,0,0,0,0),
		('Zebra turkeyfish', 0,0,0,1,1,1,1,1,1,1,1,0),
		('Blowfish', 1,1,0,0,0,0,0,0,0,0,1,1),
		('Puffer fish', 0,0,0,0,0,0,1,1,1,0,0,0),
		('Anchovy', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Horse mackerel', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Barred knifejaw', 0,0,1,1,1,1,1,1,1,1,1,0),
		('Sea bass', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Red snapper', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Dab', 1,1,1,1,0,0,0,0,0,1,1,1),
		('Olive Flounder', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Squid', 1,1,1,1,1,1,1,1,0,0,0,1),
		('Moray eel', 0,0,0,0,0,0,0,1,1,1,0,0),
		('Ribbon eel', 0,0,0,0,0,1,1,1,1,1,0,0),
		('Tuna', 1,1,1,1,0,0,0,0,0,0,1,1),
		('Blue marlin', 1,1,1,1,0,0,1,1,1,0,1,1),
		('Giant trevally', 0,0,0,0,1,1,1,1,1,1,0,0),
		('Mahi-mahi', 0,0,0,0,1,1,1,1,1,1,0,0),
		('Ocean sunfish', 0,0,0,0,0,0,1,1,1,0,0,0),
		('Ray', 0,0,0,0,0,0,0,1,1,1,1,0),
		('Saw shark', 0,0,0,0,0,1,1,1,1,0,0,0),
		('Hammerhead shark', 0,0,0,0,0,1,1,1,1,0,0,0),		
		('Great white shark', 0,0,0,0,0,1,1,1,1,0,0,0),
		('Whale shark', 0,0,0,0,0,1,1,1,1,0,0,0),
		('Suckerfish', 0,0,0,0,0,1,1,1,1,0,0,0),
		('Football fish', 1,1,1,0,0,0,0,0,0,0,1,1),
		('Oarfish', 1,1,1,1,1,0,0,0,0,0,0,1),
		('Barreleye', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Coelacanth', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Common butterfly', 1,1,1,1,1,1,0,0,1,1,1,1),
		('Yellow butterfly', 0,0,1,1,1,1,0,0,1,1,0,0),
		('Tiger butterfly', 0,0,1,1,1,1,1,1,1,0,0,0),
		('Peacock butterfly', 0,0,1,1,1,1,0,0,0,0,0,0),
		('Common bluebottle', 0,0,0,1,1,1,1,1,0,0,0,0),
		('Paper kite butterfly', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Great purple emperor', 0,0,0,0,1,1,1,1,0,0,0,0),
		('Monarch butterfly', 0,0,0,0,0,0,0,0,1,1,1,0),
		('Emperor butterfly', 1,1,1,0,0,1,1,1,1,0,0,1),
		('Agrias butterfly', 0,0,0,1,1,1,1,1,1,0,0,0),
		('Rajah Brooke''s birdwing', 1,1,0,1,1,1,1,1,1,0,0,1),
		('Queen Alexandra''s birdwing', 0,0,0,0,1,1,1,1,1,0,0,0),
		('Moth', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Atlas moth', 0,0,0,1,1,1,1,1,1,0,0,0),
		('Madagascan sunset moth', 0,0,0,1,1,1,1,1,1,0,0,0),
		('Long locust', 0,0,0,1,1,1,1,1,1,1,1,0),
		('Migratory locust', 0,0,0,0,0,0,0,1,1,1,1,0),
		('Rice grasshopper', 0,0,0,0,0,0,0,1,1,1,1,0),
		('Grasshopper', 0,0,0,0,0,0,1,1,1,0,0,0),
		('Cricket', 0,0,0,0,0,0,0,0,1,1,1,0),
		('Bell cricket', 0,0,0,0,0,0,0,0,1,1,0,0),
		('Mantis', 0,0,1,1,1,1,1,1,1,1,1,0),
		('Orchid mantis', 0,0,1,1,1,1,1,1,1,1,1,0),
		('Honeybee', 0,0,1,1,1,1,1,0,0,0,0,0),
		('Wasp', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Brown cicada', 0,0,0,0,0,0,1,1,0,0,0,0),
		('Robust cicada', 0,0,0,0,0,0,1,1,0,0,0,0),
		('Giant cicada', 0,0,0,0,0,0,1,1,0,0,0,0),
		('Walker cicada', 0,0,0,0,0,0,0,1,1,0,0,0),
		('Evening cicada', 0,0,0,0,0,0,1,1,0,0,0,0),
		('Cicada shell', 0,0,0,0,0,0,1,1,0,0,0,0),
		('Red dragonfly', 0,0,0,0,0,0,0,0,1,1,0,0),
		('Darner dragonfly', 0,0,0,1,1,1,1,1,1,1,0,0),
		('Banded dragonfly', 0,0,0,0,1,1,1,1,1,1,0,0),
		('Damselfly', 1,1,0,0,0,0,0,0,0,0,1,1),
		('Firefly', 0,0,0,0,0,1,0,0,0,0,0,0),
		('Mole Cricket', 1,1,1,1,1,0,0,0,0,0,1,1),
		('Pondskater', 0,0,0,0,1,1,1,1,1,0,0,0),
		('Diving beetle', 0,0,0,0,1,1,1,1,1,0,0,0),
		('Giant water bug', 0,0,0,1,1,1,1,1,1,0,0,0),
		('Stinkbug', 0,0,1,1,1,1,1,1,1,1,0,0),
		('Man-faced stink bug', 0,0,1,1,1,1,1,1,1,1,0,0),
		('Ladybug', 0,0,1,1,1,1,0,0,0,1,0,0),
		('Tiger beetle', 0,1,1,1,1,1,1,1,1,1,0,0),
		('Jewel beetle', 0,0,0,1,1,1,1,1,0,0,0,0),
		('Violin beetle', 0,0,0,0,1,1,0,0,1,1,1,0),
		('Citrus long-horned beetle', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Rosalia batesi beetle', 0,0,0,0,1,1,1,1,1,0,0,0),
		('Blue weevil beetle', 0,0,0,0,0,0,1,1,0,0,0,0),
		('Dung beetle', 1,1,0,0,0,0,0,0,0,0,0,1),
		('Earth-boring dung beetle', 0,0,0,0,0,0,1,1,1,0,0,0),
		('Scarab beetle', 0,0,0,0,0,0,1,1,0,0,0,0),
		('Drone beetle', 0,0,0,0,0,1,1,1,0,0,0,0),
		('Goliath beetle', 0,0,0,0,0,1,1,1,1,0,0,0),
		('Saw stag', 0,0,0,0,0,0,1,1,0,0,0,0),
		('Miyama stag', 0,0,0,0,0,0,1,1,0,0,0,0),
		('Giant stag', 0,0,0,0,0,0,1,1,0,0,0,0),
		('Rainbow stag', 0,0,0,0,0,1,1,1,1,0,0,0),
		('Cyclommatus stag', 0,0,0,0,0,0,1,1,0,0,0,0),
		('Golden stag', 0,0,0,0,0,0,1,1,0,0,0,0),
		('Giraffe stag', 0,0,0,0,0,0,1,1,0,0,0,0),
		('Horned dynastid', 0,0,0,0,0,0,1,1,0,0,0,0),
		('Horned atlas', 0,0,0,0,0,0,1,1,0,0,0,0),
		('Horned elephant', 0,0,0,0,0,0,1,1,0,0,0,0),
		('Horned hercules', 0,0,0,0,0,0,1,1,0,0,0,0),
		('Walking stick', 0,0,0,0,0,0,1,1,1,1,1,0),
		('Walking leaf', 0,0,0,0,0,0,1,1,1,0,0,0),
		('Bagworm', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Ant', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Hermit crab', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Wharf roach', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Fly', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Mosquito', 0,0,0,0,0,1,1,1,1,0,0,0),
		('Flea', 0,0,0,0,0,1,1,1,1,1,1,0),
		('Snail', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Pill bug', 1,1,1,1,1,1,0,0,1,1,1,1),
		('Centipede', 1,1,1,1,1,1,0,0,1,1,1,1),
		('Spider', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Tarantula', 1,1,1,1,0,0,0,0,0,0,1,1),
		('Scorpion', 0,0,0,0,1,1,1,1,1,1,0,0),
		('Seaweed', 1,1,1,1,1,1,1,0,0,1,1,1),
		('Sea grapes', 0,0,0,0,0,1,1,1,1,0,0,0),
		('Sea cucumber', 1,1,1,1,0,0,0,0,0,0,1,1),
		('Sea pig', 1,1,0,0,0,0,0,0,0,0,1,1),
		('Sea star', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Sea urchin', 0,0,0,0,1,1,1,1,1,0,0,0),
		('Slate pencil urchin', 0,0,0,0,1,1,1,1,1,0,0,0),
		('Sea anemone', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Moon jellyfish', 0,0,0,0,0,0,1,1,1,0,0,0),
		('Sea slug', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Pearl oyster', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Mussel', 0,0,0,0,0,1,1,1,1,1,1,1),
		('Oyster', 1,1,0,0,0,0,0,0,1,1,1,1),
		('Scallop', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Whelk', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Turban shell', 0,0,1,1,1,0,0,0,1,1,1,1),
		('Abalone', 1,0,0,0,0,1,1,1,1,1,1,1),
		('Gigas giant clam', 0,0,0,0,1,1,1,1,1,0,0,0),
		('Chambered nautilus', 0,0,1,1,1,1,0,0,1,1,1,0),
		('Octopus', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Umbrella octopus', 0,0,1,1,1,0,0,0,1,1,1,0),
		('Vampire squid', 0,0,0,0,1,1,1,1,0,0,0,0),
		('Firefly squid', 0,0,1,1,1,1,0,0,0,0,0,0),
		('Gazami crab', 0,0,0,0,0,1,1,1,1,1,1,0),
		('Dungeoness crab', 1,1,1,1,1,0,0,0,0,0,1,1),
		('Snow crab', 1,1,1,1,0,0,0,0,0,0,1,1),
		('Red king crab', 1,1,1,0,0,0,0,0,0,0,1,1),
		('Acorn barnacle', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Spider crab', 0,0,1,1,0,0,0,0,0,0,0,0),
		('Tiger prawn', 0,0,0,0,0,1,1,1,1,0,0,0),
		('Sweet shrimp', 1,1,0,0,0,0,0,0,1,1,1,1),
		('Mantis shrimp', 1,1,1,1,1,1,1,1,1,1,1,1),
		('Spiny lobster', 0,0,0,0,0,0,0,0,0,1,1,1),
		('Lobster', 1,0,0,1,1,1,0,0,0,0,0,1),
		('Giant isopod', 0,0,0,0,0,0,1,1,1,1,0,0),
		('Horseshoe crab', 0,0,0,0,0,0,1,1,1,0,0,0),
		('Sea pineapple', 0,0,0,1,1,1,1,1,0,0,0,0),
		('Spotted garden eel', 0,0,0,0,1,1,1,1,1,1,0,0),
		('Flatworm', 0,0,0,0,0,0,0,1,1,0,0,0),
		('Venus'' flower basket', 1,1,0,0,0,0,0,0,0,1,1,1)
GO

/*
	Creates catchable_hour table
*/
print '' print '*** creating catchable_hour table ***'
CREATE TABLE [dbo].[catchable_hours](
	critter_id 				[nvarchar](40) 		NOT NULL,
    hour1am					[bit]			 	NOT NULL,
	hour2am					[bit]			 	NOT NULL,
	hour3am					[bit]			 	NOT NULL,
	hour4am					[bit]			 	NOT NULL,
	hour5am					[bit]			 	NOT NULL,
	hour6am					[bit]			 	NOT NULL,
	hour7am					[bit]			 	NOT NULL,
	hour8am					[bit]			 	NOT NULL,
	hour9am					[bit]			 	NOT NULL,
	hour10am				[bit]			 	NOT NULL,
	hour11am				[bit]			 	NOT NULL,
	hour12pm				[bit]				NOT NULL,
	hour1pm					[bit]			 	NOT NULL,
	hour2pm					[bit]			 	NOT NULL,
	hour3pm					[bit]			 	NOT NULL,
	hour4pm					[bit]			 	NOT NULL,
	hour5pm					[bit]			 	NOT NULL,
	hour6pm					[bit]			 	NOT NULL,
	hour7pm					[bit]			 	NOT NULL,
	hour8pm					[bit]			 	NOT NULL,
	hour9pm					[bit]			 	NOT NULL,
	hour10pm				[bit]			 	NOT NULL,
	hour11pm				[bit]			 	NOT NULL,
	hour12am				[bit]			 	NOT NULL,
    CONSTRAINT [pk_critter_id_catchabl_hour] PRIMARY KEY ([critter_id]),
	CONSTRAINT [fk_critter_critter_id_catchable_hours] FOREIGN KEY ([critter_id])
        REFERENCES [dbo].[critter]([critter_id])
) 
GO

/*
	catchable_hour test records
*/
print '' print '*** creating catchable_hour test records ***'
INSERT INTO [dbo].[catchable_hours]
		([critter_id],[hour1am],[hour2am],[hour3am],[hour4am],[hour5am],[hour6am],[hour7am],[hour8am],[hour9am],[hour10am],[hour11am],[hour12pm],[hour1pm],[hour2pm],[hour3pm],[hour4pm],[hour5pm],[hour6pm],[hour7pm],[hour8pm],[hour9pm],[hour10pm],[hour11pm],[hour12am])
	VALUES
		('Bitterling', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Pale chub', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0),
		('Crucian carp', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Dace', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0),
		('Carp', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Koi', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0),
		('Goldfish', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Pop-eyed goldfish', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0),
		('Ranchu goldfish', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0),
		('Killifish', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Crawfish', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Soft-shelled turtle', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0),
		('Snapping turtle', 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1),
		('Tadpole', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Frog', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Freshwater goby', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0),
		('Loach', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Catfish', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0),
		('Giant snakehead', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0),
		('Bluegill', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0),
		('Yellow perch', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Black bass', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Tilapia', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Pike', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Pond smelt', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Sweetfish', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Cherry salmon', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0),
		('Char', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Golden trout', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0),
		('Stringfish', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0),
		('Salmon', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('King salmon', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Mitten crab', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0),
		('Guppy', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0),
		('Nibble fish', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0),
		('Angelfish', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0),
		('Betta', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0),
		('Neon tetra', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0),
		('Rainbowfish', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0),
		('Piranha', 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1),
		('Arowana', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0),
		('Dorado', 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1),
		('Gar', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0),
		('Arapaima', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0),
		('Saddled bichir', 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1),
		('Sturgeon', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Sea butterfly', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Sea horse', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Clown fish', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Surgeonfish', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Butterfly fish', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Napoleonfish', 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1),
		('Zebra turkeyfish', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Blowfish', 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1),
		('Puffer fish', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Anchovy', 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1),
		('Horse mackerel', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Barred knifejaw', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Sea bass', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Red snapper', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Dab', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Olive flounder', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Squid', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Moray eel', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Ribbon eel', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Tuna', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Blue Marlin', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Giant trevally', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Mahi-mahi', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Ocean sunfish', 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1),
		('Ray', 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1),
		('Saw shark', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0),
		('Hammerhead shark', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0),
		('Great white shark', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0),
		('Whale shark', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Suckerfish', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Football fish', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0),
		('Oarfish', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Barreleye', 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1),
		('Coelacanth', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Common butterfly', 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0),
		('Yellow butterfly', 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0),
		('Tiger butterfly', 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0),
		('Peacock butterfly', 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0),
		('Common bluebottle', 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0),
		('Paper kite butterfly', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0),
		('Great purple emperor', 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0),
		('Monarch butterfly', 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0),
		('Emperor butterfly', 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1),
		('Agrias butterfly', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0),
		('Rajah Brooke''s birdwing', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0),
		('Queen Alexandra''s birdwing', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0),
		('Moth', 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1),
		('Atlas moth', 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1),
		('Madagascan sunset moth', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0),
		('Long locust', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0),
		('Migratory locust', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0),
		('Rice grasshopper', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0),
		('Grasshopper', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0),
		('Cricket', 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1),
		('Bell cricket', 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1),
		('Mantis', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0),
		('Orchid mantis', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0),
		('Honeybee', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0),
		('Wasp', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Brown cicada', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0),
		('Robust cicada', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0),
		('Giant cicada', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0),
		('Walker cicada', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0),
		('Evening cicada', 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0),
		('Cicada shell', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Red dragonfly', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0),
		('Darner dragonfly', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0),
		('Banded dragonfly', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0),
		('Damselfly', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Firefly', 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1),
		('Mole cricket', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Pondskater', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0),
		('Diving beetle', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0),
		('Giant water bug', 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1),
		('Stinkbug', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Man-faced stink bug', 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1),
		('Ladybug', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0),
		('Tiger beetle', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Jewel beetle', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Violin beetle', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Citrus long-horned beetle', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Rosalia batesi beetle', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Blue weevil beetle', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Dung beetle', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Earth-boring dung beetle', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Scarab beetle', 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1),
		('Drone beetle', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Goliath beetle', 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1),
		('Saw stag', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Miyama stag', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Giant stag', 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1),
		('Rainbow stag', 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1),
		('Cyclommatus stag', 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1),
		('Golden stag', 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1),
		('Horned dynastid', 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1),
		('Horned atlas', 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1),
		('Horned elephant', 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1),
		('Horned hercules', 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1),
		('Walking stick', 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0),
		('Walking leaf', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Bagworm', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Ant', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Hermit crab', 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1),
		('Wharf roach', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Fly', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Mosquito', 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1),
		('Flea', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Snail', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Pill bug', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1),
		('Centipede', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1),
		('Spider', 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1),
		('Tarantula', 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1),
		('Scorpion', 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1),
		('Seaweed', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Sea grapes', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Sea cucumber', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Sea pig', 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Sea star', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Sea urchin', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Slate pencil urchin', 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Sea anemone', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Moon jellyfish', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Sea slug', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Pearl oyster', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Mussel', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Oyster', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Scallop', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Whelk', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Turban shell', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Abalone', 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Gigas giant clam', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Chambered nautilus', 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Octopus', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Umbrella octopus', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Vampire squid', 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1),
		('Firefly squid', 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1),
		('Gazami crab', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Dungeoness crab', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Snow crab', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Red king crab', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Acorn barnacle', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Spider crab', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Tiger prawn', 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Sweet shrimp', 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Mantis shrimp', 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Spiny lobster', 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1),
		('Lobster', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Giant isopod', 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1),
		('Horseshoe crab', 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1),
		('Sea pineapple', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Spotted garden eel', 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0),
		('Flatworm', 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1),
		('Venus'' flower basket', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)
GO

/*
	Create caught_by table
*/
print '' print '*** creating caught_by table ***'
CREATE TABLE caught_by(
	villager_id				[int]				NOT NULL,
    critter_id 				[nvarchar](40)		NOT NULL,
    caught_date 			[date]				NULL,
    CONSTRAINT [pk_caught_by_villager_id_critter_id] PRIMARY KEY ([villager_id], [critter_id]),
    CONSTRAINT [fk_villager_villager_id] FOREIGN KEY ([villager_id])
        REFERENCES [dbo].[villager]([villager_id]),
	CONSTRAINT [fk_critter_critter_id_caught_by] FOREIGN KEY ([critter_id])
        REFERENCES [dbo].[critter]([critter_id])
)
GO

/*
	caught_by test records
*/
print '' print '*** creating caught_by test records ***'
INSERT INTO [dbo].[caught_by]
		([villager_id], [critter_id], [caught_date])
	VALUES
		(100003, 'Madagascan sunset moth', '2020-08-09'),
		(100003, 'Abalone', '2020-06-15'),
		(100002, 'Saw shark', '2020-07-15'),
		(100002, 'Red king crab', '2020-01-23'),
		(100001, 'Snow crab', '2020-02-23'),
		(100003, 'Snail', '2020-09-08'),
		(100000, 'Firefly', '2020-06-15'),
		(100001, 'Goliath beetle', '2020-08-29'),
		(100003, 'Giant trevally', '2020-05-07'),
		(100000, 'Saw shark', '2020-08-14'),
		(100001, 'Sea cucumber', '2021-01-05'),
		(100000, 'Rajah Brooke''s birdwing', '2021-04-21'),
		(100000, 'Golden trout', '2020-03-12'),
		(100001, 'Yellow perch', '2020-10-24'),
		(100000, 'Coelacanth', '2021-04-08'),
		(100003, 'Arapaima', '2020-07-02'),
		(100003, 'Vampire squid', '2020-08-05'),
		(100002, 'Long locust', '2020-11-11'),
		(100003, 'Sea horse', '2020-05-19'),
		(100000, 'Sea pineapple', '2021-04-25'),
		(100002, 'Crawfish', '2020-04-25'),
		(100003, 'Acorn barnacle', '2020-12-02'),
		(100002, 'Sea butterfly', '2021-02-22'),
		(100000, 'Dab', '2020-10-20'),
		(100002, 'Dorado', '2020-08-11'),
		(100003, 'Rainbowfish', '2020-07-26'),
		(100001, 'Horse mackerel', '2020-06-14'),
		(100003, 'Bagworm', '2020-06-06'),
		(100003, 'Hermit crab', '2020-11-13'),
		(100002, 'Horseshoe crab', '2021-07-11'),
		(100003, 'Sturgeon', '2020-09-30'),
		(100000, 'Great white shark', '2021-09-20'),
		(100003, 'Tiger butterfly', '2021-04-05'),
		(100001, 'Giraffe stag', '2020-08-29'),
		(100001, 'Horseshoe crab', '2020-08-05'),
		(100003, 'Miyama stag', '2020-07-06'),
		(100003, 'Sea urchin', '2020-05-27'),
		(100003, 'Earth-boring dung beetle', '2020-07-14'),
		(100002, 'Goliath beetle', '2020-06-09'),
		(100003, 'Centipede', '2020-02-04'),
		(100000, 'Madagascan sunset moth', '2020-06-15'),
		(100000, 'Catfish', '2020-10-10'),
		(100000, 'Bagworm', '2021-04-29'),
		(100002, 'Gigas giant clam', '2020-10-01'),
		(100002, 'Ocean sunfish', '2020-08-04'),
		(100000, 'Miyama stag', '2020-08-12'),
		(100000, 'Abalone', '2021-01-22'),
		(100001, 'Tuna', '2020-12-02'),
		(100000, 'Cricket', '2020-11-20'),
		(100003, 'Horseshoe crab', '2020-07-21'),
		(100001, 'Umbrella octopus', '2020-05-27')
GO

/*
	Creates shadow_size table
*/
print '' print '*** creating shadow_size table ***'
CREATE TABLE [dbo].[shadow_size](
	shadow_size_id 			[nvarchar](40) 		NOT NULL,
    CONSTRAINT [pk_shadow_size_id] PRIMARY KEY ([shadow_size_id])
) 
GO

/*
	shadow_size test records
*/
print '' print '*** creating shadow_size test records ***'
INSERT INTO [dbo].[shadow_size]
		([shadow_size_id])
	VALUES
		('Smallest'),
		('Tiny'),
		('Small'),
		('Medium'),
		('Large'),
		('X Large'),
		('Largest'),
		('Large (Fin)'),
		('Largest (Fin)'),
		('Narrow'),
		('Huge')
GO

/*
	Creates fish table 
*/
print '' print '*** creating fish table ***'
CREATE TABLE fish(
	critter_id 				[nvarchar](40)	 	NOT NULL,
    location_id 			[nvarchar](40) 		NOT NULL,
    shadow_size_id			[nvarchar](40) 		NOT NULL,
    CONSTRAINT [pk_fish_critter_id] PRIMARY KEY ([critter_id], [location_id])
    , CONSTRAINT [fk_critter_critter_id_fish] FOREIGN KEY ([critter_id])
        REFERENCES [dbo].[critter]([critter_id])
	, CONSTRAINT [fk_location_location_id_fish_location] FOREIGN KEY ([location_id])
        REFERENCES [dbo].[fish_location]([location_id])
	, CONSTRAINT [fk_shadow_size_shadow_size_id_fish] FOREIGN KEY ([shadow_size_id])
        REFERENCES [dbo].[shadow_size]([shadow_size_id])
) 
GO

INSERT INTO [dbo].[fish]
		([critter_id], [location_id], [shadow_size_id])
 	VALUES
		('Bitterling', 'River', 'Smallest'),
		('Pale chub', 'River' , 'Smallest'),
		('Crucian carp', 'River' , 'Small'),
		('Dace', 'River' , 'Medium'),
		('Carp', 'Pond', 'Large'),
		('Koi', 'Pond', 'Large'),
		('Goldfish', 'Pond', 'Smallest'),
		('Pop-eyed goldfish', 'Pond', 'Smallest'),
		('Ranchu goldfish', 'Pond', 'Small'),
		('Killifish', 'Pond', 'Smallest'),
		('Crawfish', 'Pond', 'Small'),
		('Soft-shelled turtle', 'River' , 'Large'),
		('Snapping turtle', 'River' , 'X Large'),
		('Tadpole', 'Pond', 'Smallest'),
		('Frog', 'Pond', 'Small'),
		('Freshwater goby', 'River' , 'Small'),
		('Loach', 'River', 'Small'),
		('Catfish', 'Pond', 'Large'),
		('Giant snakehead', 'Pond', 'X Large'),
		('Bluegill', 'River', 'Small'),
		('Yellow Perch', 'River', 'Medium'),
		('Black Bass', 'River', 'Large'),
		('Tilapia', 'River', 'Medium'),
		('Pike', 'River', 'X Large'),
		('Pond Smelt', 'River', 'Small'),
		('Sweetfish', 'River', 'Medium'),
		('Cherry salmon', 'River (Clifftop)', 'Medium'),
		('Char', 'River (Clifftop)', 'Medium'),
		('Golden trout', 'River (Clifftop)', 'Medium'),
		('Stringfish', 'River (Clifftop)', 'X Large'),
		('Salmon', 'River (Mouth)', 'Large'),
		('King salmon', 'River (Mouth)', 'Largest'),
		('Mitten crab', 'River', 'Small'),
		('Guppy', 'River', 'Smallest'),
		('Nibble fish', 'River', 'Smallest'),
		('Angelfish', 'River', 'Small'),
		('Betta', 'River', 'Small'),
		('Neon tetra', 'River', 'Smallest'),
		('Rainbowfish', 'River', 'Smallest'),
		('Piranha', 'River', 'Small'),
		('Arowana', 'River', 'Large'),
		('Dorado', 'River', 'X Large'),
		('Gar', 'Pond', 'Largest'),
		('Arapaima', 'River', 'Largest'),
		('Saddled bichir', 'River', 'Large'),
		('Sturgeon', 'River (Mouth)', 'Largest'),
		('Sea butterfly', 'Sea', 'Smallest'),
		('Sea horse', 'Sea', 'Smallest'),
		('Clown fish', 'Sea', 'Smallest'),
		('Surgeonfish', 'Sea', 'Small'),
		('Butterfly fish', 'Sea', 'Small'),
		('Napoleonfish', 'Sea', 'Largest'),
		('Zebra turkeyfish', 'Sea', 'Medium'),
		('Blowfish', 'Sea', 'Medium'),
		('Puffer fish', 'Sea', 'Medium'),
		('Anchovy', 'Sea', 'Small'),
		('Horse mackerel', 'Sea', 'Small'),
		('Barred knifejaw', 'Sea', 'Medium'),
		('Sea bass', 'Sea', 'X Large'),
		('Red snapper', 'Sea', 'Large'),
		('Dab', 'Sea', 'Medium'),
		('Olive flounder', 'Sea', 'Large'),
		('Squid', 'Sea', 'Medium'),
		('Moray eel', 'Sea', 'Narrow'),
		('Ribbon eel', 'Sea', 'Narrow'),
		('Tuna', 'Pier', 'Largest'),
		('Blue marlin', 'Pier', 'Largest'),
		('Giant trevally', 'Pier', 'X Large'),
		('Mahi-mahi', 'Pier', 'X Large'),
		('Ocean sunfish', 'Sea', 'Largest (Fin)'),
		('Ray', 'Sea', 'X Large'),
		('Saw shark', 'Sea', 'Largest (Fin)'),
		('Hammerhead shark', 'Sea', 'Largest (Fin)'),
		('Great white shark', 'Sea', 'Largest (Fin)'),
		('Whale shark', 'Sea', 'Largest (Fin)'),
		('Suckerfish', 'Sea', 'Large (Fin)'),
		('Football fish', 'Sea', 'Large'),
		('Oarfish', 'Sea', 'Largest'),
		('Barreleye', 'Sea', 'Small'),
		('Coelacanth', 'Sea', 'Largest')
GO

/*
	Creates bug table
*/
print '' print '*** creating bug table ***'
CREATE TABLE bug(
	critter_id 				[nvarchar](40) 		NOT NULL,
    spot_id 				[nvarchar](40) 		NOT NULL,
    CONSTRAINT [pk_bug_critter_id] PRIMARY KEY ([critter_id]),
    CONSTRAINT [fk_critter_critter_id_bug] FOREIGN KEY ([critter_id])
        REFERENCES [dbo].[critter]([critter_id]),
	CONSTRAINT [fk_bug_finding_spot_spot_id] FOREIGN KEY ([spot_id])
        REFERENCES [dbo].[bug_finding_spot]([spot_id])
)
GO

/*
	bug test records
*/
print '' print '*** creating bug test records ***'
INSERT INTO [dbo].[bug]
		([critter_id], [spot_id])
	VALUES
		('Common butterfly', 'Flying'),
		('Yellow butterfly', 'Flying'),
		('Tiger butterfly', 'Flying'),
		('Peacock butterfly', 'Flying by hybrid flowers'),
		('Common bluebottle', 'Flying'),
		('Paper kite butterfly', 'Flying'),
		('Great purple emperor', 'Flying'),
		('Monarch butterfly', 'Flying'),
		('Emperor butterfly', 'Flying'),
		('Agrias butterfly', 'Flying'),
		('Rajah Brooke''s birdwing', 'Flying by purple flowers'),
		('Queen Alexandra''s birdwing', 'Flying'),
		('Moth', 'Flying by light'),
		('Atlas moth', 'On trees'),
		('Madagascan sunset moth', 'Flying'),
		('Long locust', 'On the ground'),
		('Migratory locust', 'On the ground'),
		('Rice grasshopper', 'On the ground'),
		('Grasshopper', 'On the ground'),
		('Cricket', 'On the ground'),
		('Bell cricket', 'On the ground'),
		('Mantis', 'On flowers'),
		('Orchid mantis', 'On flowers (white)'),
		('Honeybee', 'Flying'),
		('Wasp', 'Shaken from trees'),
		('Brown cicada', 'On trees'),
		('Robust cicada', 'On trees'),
		('Giant cicada', 'On trees'),
		('Walker cicada', 'On trees'),
		('Evening cicada', 'On trees'),
		('Cicada shell', 'On trees'),
		('Red dragonfly', 'Flying'),
		('Darner dragonfly', 'Flying'),
		('Banded dragonfly', 'Flying'),
		('Damselfly', 'Flying'),
		('Firefly', 'Flying'),
		('Mole cricket', 'Underground'),
		('Pondskater', 'On Ponds and rivers'),
		('Diving beetle', 'On Ponds and rivers'),
		('Giant water bug', 'On Ponds and rivers'),
		('Stinkbug', 'On flowers'),
		('Man-faced stink bug', 'On flowers'),
		('Ladybug', 'On flowers'),
		('Tiger beetle', 'On the ground'),
		('Jewel beetle', 'On tree stumps'),
		('Violin beetle', 'On tree stumps'),
		('Citrus long-horned beetle', 'On tree stumps'),
		('Rosalia batesi beetle', 'On tree stumps'),
		('Blue weevil beetle', 'On trees (Coconut)'),
		('Dung beetle', 'On the ground (Rolling Snowballs)'),
		('Earth-boring dung beetle', 'On the ground'),
		('Scarab beetle', 'On trees'),
		('Drone beetle', 'On trees'),
		('Goliath beetle', 'On trees (Coconut)'),
		('Saw stag', 'On trees'),
		('Miyama stag', 'On trees'),
		('Giant stag', 'On trees'),
		('Rainbow stag', 'On trees'),
		('Cyclommatus stag', 'On trees (Coconut)'),
		('Golden stag', 'On trees (Coconut)'),
		('Giraffe stag', 'On trees (Coconut)'),
		('Horned dynastid', 'On trees'),
		('Horned atlas', 'On trees (Coconut)'),
		('Horned elephant', 'On trees (Coconut)'),
		('Horned hercules', 'On trees (Coconut)'),
		('Walking stick', 'On trees'),
		('Walking leaf', 'Under trees disguised as leaves'),
		('Bagworm', 'Shaken from trees'),
		('Ant', 'On rotten food'),
		('Hermit crab', 'On the beach disguised as shells'),
		('Wharf roach', 'On beach rocks'),
		('Fly', 'On trash items'),
		('Mosquito', 'Flying'),
		('Flea', 'On villagers'),
		('Snail', 'On rocks or bushes'),
		('Pill bug', 'Under rocks'),
		('Centipede', 'Under rocks'),
		('Spider', 'Shaken from trees'),
		('Tarantula', 'On the ground'),
		('Scorpion', 'On the ground')
GO

/*
	Creates movement table
*/
print '' print '*** creating movement table ***'
CREATE TABLE movement(
	movement_id 			[nvarchar](40) 		NOT NULL,
    CONSTRAINT [pk_movement_movement_id] PRIMARY KEY ([movement_id])
) 
GO

/*
	movement test records
*/
print '' print '*** creating movement test records ***'
INSERT INTO [dbo].[movement]
		([movement_id])
	VALUES
		('Stationary'),
		('Slow consistent movement'),
		('Slow short lunges'),
		('Slow long lunges'),
		('Slow'),
		('Slow short movement'),
		('Moderate consistent movement'),
		('Moderate short lunges'),
		('Moderate long lunges'),
		('Quick long lunges'),
		('Quick short lunges'),
		('Quick'),
		('Fast')
GO

/*
	Creates sea_creature table
*/
print '' print '*** creating sea_creature table ***'
CREATE TABLE [dbo].[sea_creature](
	critter_id 				[nvarchar](40) 		NOT NULL,
    shadow_size_id 			[nvarchar](40) 		NOT NULL,
    movement_id 			[nvarchar](40) 		NOT NULL,
    CONSTRAINT [pk_sea_creature_critter_id] PRIMARY KEY ([critter_id]),
    CONSTRAINT [fk_critter_critter_id_sea_creature] FOREIGN KEY ([critter_id])
        REFERENCES [dbo].[critter]([critter_id]),
	CONSTRAINT [fk_shadow_size_shadow_size_id_sea_creature] FOREIGN KEY ([shadow_size_id])
        REFERENCES [dbo].[shadow_size]([shadow_size_id]),
	CONSTRAINT [fk_movement_movement_id] FOREIGN KEY ([movement_id])
        REFERENCES [dbo].[movement]([movement_id])
) 
GO

/*
	sea_creature test records
*/
print '' print '*** creating sea_creature test records ***'
INSERT INTO [dbo].[sea_creature]
		([critter_id], [shadow_size_id], [movement_id])
	VALUES	
		('Seaweed', 'Large', 'Stationary'),
		('Sea grapes', 'Small', 'Stationary'),
		('Sea cucumber', 'Medium', 'Slow consistent movement'),
		('Sea pig', 'Small', 'Quick long lunges'),
		('Sea star', 'Small', 'Slow short lunges'),
		('Sea urchin', 'Small', 'Slow consistent movement'),
		('Slate pencil urchin', 'Medium', 'Moderate consistent movement'),
		('Sea anemone', 'Large', 'Stationary'),
		('Moon jellyfish', 'Small', 'Slow consistent movement'),
		('Sea slug', 'Tiny', 'Slow consistent movement'),
		('Pearl oyster', 'Small', 'Moderate long lunges'),
		('Mussel', 'Small', 'Slow consistent movement'),
		('Oyster', 'Small', 'Moderate short lunges'),
		('Scallop', 'Medium', 'Slow long lunges'),
		('Whelk', 'Small', 'Slow consistent movement'),
		('Turban shell', 'Small', 'Slow'),
		('Abalone', 'Medium', 'Moderate consistent movement'),
		('Gigas giant clam', 'Huge', 'Quick long lunges'),
		('Chambered nautilus', 'Medium', 'Slow'),
		('Octopus', 'Medium', 'Moderate long lunges'),
		('Umbrella octopus', 'Small', 'Quick long lunges'),
		('Vampire squid', 'Medium', 'Quick long lunges'),
		('Firefly squid', 'Tiny', 'Slow'),
		('Gazami crab', 'Medium', 'Moderate long lunges'),
		('Dungeoness crab', 'Medium', 'Moderate consistent movement'),
		('Snow crab', 'Large', 'Quick short lunges'),
		('Red king crab', 'Large', 'Quick'),
		('Acorn barnacle', 'Tiny', 'Stationary'),
		('Spider crab', 'Huge', 'Quick'),
		('Tiger prawn', 'Small', 'Moderate consistent movement'),
		('Sweet shrimp', 'Small', 'Slow'),
		('Mantis shrimp', 'Small', 'Quick short lunges'),
		('Spiny lobster', 'Large', 'Fast'),
		('Lobster', 'Large', 'Quick'),
		('Giant isopod', 'Medium', 'Quick long lunges'),
		('Horseshoe crab', 'Medium', 'Quick short lunges'),
		('Sea pineapple', 'Small', 'Slow long lunges'),
		('Spotted garden eel', 'Small', 'Slow consistent movement'),
		('Flatworm', 'Tiny', 'Slow short movement'),
		('Venus'' flower basket', 'Medium', 'Quick long lunges')
GO

/* vilager login related stored procedures */

print '' print '*** creating sp_authenticate_user ***'
GO

CREATE PROCEDURE [dbo].[sp_authenticate_user]
(
	@login_name		   	[nvarchar](16),
	@password_hash		[nvarchar](64)
)
AS
	BEGIN
		SELECT COUNT([login_name]) AS 'Authenticated'
		FROM [Villager]
		WHERE @login_name = [login_name]
			AND @password_hash = [password_hash]
			AND [active] = 1
	END
GO

print '' print '*** creating sp_authenticate_user_by_email ***'
GO

CREATE PROCEDURE [dbo].[sp_authenticate_user_by_email]
(
	@email	   			[nvarchar](250),
	@password_hash		[nvarchar](64)
)
AS
	BEGIN
		SELECT COUNT([email_address]) AS 'Authenticated'
		FROM [Villager]
		WHERE @email = [email_address]
			AND @password_hash = [password_hash]
			AND [active] = 1
	END
GO

print '' print '*** sp_select_villager_by_login_name ***'
GO
CREATE PROCEDURE [dbo].[sp_select_villager_by_login_name]
(
	@login_name	   		[nvarchar](16)
)
AS
	BEGIN
		SELECT [villager_id],[character_name], [email_address], [Active]
		FROM [villager]
		WHERE @login_name = [login_name]
	END
GO

print '' print '*** sp_select_villager_by_email ***'
GO
CREATE PROCEDURE [dbo].[sp_select_villager_by_email]
(
	@email   		[nvarchar](250)
)
AS
	BEGIN
		SELECT [villager_id], [character_name], [login_name], [Active]
		FROM [Villager]
		WHERE @email = [email_address]
	END
GO

print '' print '*** sp_select_villager_by_villager_id***'
GO
CREATE PROCEDURE [dbo].[sp_select_villager_by_villager_id]
(
	@villager_id   		[int]
)
AS
	BEGIN
		SELECT [character_name], [login_name], [email_address], [Active]
		FROM [Villager]
		WHERE @villager_id = [villager_id]
	END
GO

print '' print '*** sp_select_villager_roles_by_login_name ***'
GO
CREATE PROCEDURE [dbo].[sp_select_villager_roles_by_villager_id]
(
	@villager_id			[int]
)
AS
	BEGIN
		SELECT [role_id]
		FROM [villager_role] 
		WHERE @villager_id = [villager_id]
	END
GO

print '' print '*** sp_select_all_roles ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_roles]
AS
	BEGIN
		SELECT [role_id]
		FROM [role] 
	END
GO

print '' print '*** sp_update_passwordHash ***'
GO
CREATE PROCEDURE [dbo].[sp_update_passwordHash]
(
	@login_name			[nvarchar](16),
	@old_password_hash	[nvarchar](64),
	@new_password_hash	[nvarchar](64)
)
AS
	BEGIN
		UPDATE	[villager]
		SET		[password_hash] = @new_password_hash
		WHERE 	@login_name = [login_name] 
		  AND 	[password_hash] = @old_password_hash
		RETURN @@ROWCOUNT
	END
GO

print '' print '*** sp_select_all_critters ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_critters]
AS
	BEGIN
		SELECT [critter_id], [rain_needed], [is_in_museum], [price], [museum_by_login_name], [critter].[critter_type_id], [critter_type].[catch_description], [active]
		FROM [critter] JOIN [critter_type] ON [critter].[critter_type_id] = [critter_type].[critter_type_id]
	END
GO



print '' print '*** sp_select_all_active_critters ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_active_critters]
AS
	BEGIN
		SELECT [critter_id], [rain_needed], [is_in_museum], [price], [museum_by_login_name], [critter].[critter_type_id], [critter_type].[catch_description]
		FROM [critter] JOIN [critter_type] ON [critter].[critter_type_id] = [critter_type].[critter_type_id]
		WHERE [active] = 1
	END
GO

print '' print '*** sp_select_catch_months_by_critter_id ***'
GO
CREATE PROCEDURE [dbo].[sp_select_catch_months_by_critter_id]
(
	@critter_id 	[nvarchar](40)
)
AS
	BEGIN
		SELECT [jan],[feb],[mar],[apr],[may],[june],[july],[aug],[sep],[octo],[nov],[dec]
		FROM [catchable_month]
		WHERE [critter_id] = @critter_id
	END
GO

print '' print '*** sp_select_catch_hours_by_critter_id ***'
GO
CREATE PROCEDURE [dbo].[sp_select_catch_hours_by_critter_id]
(
	@critter_id 	[nvarchar](40)
)
AS
	BEGIN
		SELECT [hour1am], [hour2am], [hour3am], [hour4am], [hour5am], [hour6am], 
				[hour7am], [hour8am], [hour9am], [hour10am], [hour11am], [hour12pm], 
				[hour1pm], [hour2pm], [hour3pm], [hour4pm], [hour5pm], [hour6pm], 
				[hour7pm], [hour8pm], [hour9pm], [hour10pm], [hour11pm], [hour12am]
		FROM [catchable_hours]
		WHERE [critter_id] = @critter_id
	END
GO

print '' print '*** sp_select_all_critters_caught_by_villager_id ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_critters_caught_by_villager_id]
(
	@villager_id 	[int]
)
AS
	BEGIN
		SELECT [caught_by].[caught_date], [critter].[critter_id], [critter].[rain_needed], [critter].[is_in_museum], [critter].[price], [critter].[museum_by_login_name], [critter].[critter_type_id], [critter_type].[catch_description]
		FROM [caught_by] JOIN [critter] ON [caught_by].[critter_id] = [critter].[critter_id] 
						JOIN [critter_type] ON [critter].[critter_type_id] = [critter_type].[critter_type_id]
		WHERE [active] = 1 AND [caught_by].[villager_id] = @villager_id
	END
GO

print '' print '*** sp_select_caught_bys_by_critter_id ***'
GO
CREATE PROCEDURE [dbo].[sp_select_caught_bys_by_critter_id]
(
	@critter_id 	[nvarchar](40)
)
AS
	BEGIN
		SELECT [villager_id], [caught_date]
		FROM [caught_by]		
		WHERE [critter_id] = @critter_id
	END
GO

print '' print '*** sp_select_all_locations ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_locations]
AS
	BEGIN
		SELECT [location_id]
		FROM [fish_location]
	END
GO

print '' print '*** sp_select_all_shadow_sizes ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_shadow_sizes]
AS
	BEGIN
		SELECT [shadow_size_id]
		FROM [shadow_size]
	END
GO

print '' print '*** sp_select_all_movements ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_movements]
AS
	BEGIN
		SELECT [movement_id]
		FROM [movement]
	END
GO

print '' print '*** sp_select_all_bug_finding_spots ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_bug_finding_spots]
AS
	BEGIN
		SELECT [spot_id]
		FROM [bug_finding_spot]
	END
GO

print '' print '*** sp_select_fish_by_critter_id ***'
GO
CREATE PROCEDURE [dbo].[sp_select_fish_by_critter_id]
(
	@critter_id 	[nvarchar](40)
)
AS
	BEGIN
		SELECT [fish].[location_id], [fish_location].[location_description], [fish].[shadow_size_id]
		FROM [fish] JOIN [fish_location] ON [fish].[location_id] = [fish_location].[location_id]
		WHERE @critter_id = [critter_id]
	END
GO

print '' print '*** sp_select_bug_by_critter_id ***'
GO
CREATE PROCEDURE [dbo].[sp_select_bug_by_critter_id]
(
	@critter_id 	[nvarchar](40)
)
AS
	BEGIN
		SELECT [bug].[spot_id],[bug_finding_spot].[spot_description]
		FROM [bug] JOIN [bug_finding_spot] ON [bug].[spot_id] = [bug_finding_spot].[spot_id]
		WHERE @critter_id = [critter_id]
	END
GO

print '' print '*** sp_select_sea_creature_by_critter_id ***'
GO
CREATE PROCEDURE [dbo].[sp_select_sea_creature_by_critter_id]
(
	@critter_id 	[nvarchar](40)
)
AS
	BEGIN
		SELECT [shadow_size_id], [movement_id]
		FROM [sea_creature]
		WHERE @critter_id = [critter_id]
	END
GO
/*
print '' print '*** sp_update_fish ***'
GO
CREATE PROCEDURE [dbo].[sp_update_fish]
(
	@Critter_ID 				[nvarchar](40),

	@old_location_id			[nvarchar](40),
	@old_shadow_size_id			[nvarchar(40),
	
	@new_location_id			[nvarchar](40),
	@new_shadow_size_id			[nvarchar(40)
)
AS
	BEGIN
		UPDATE 	[fish]
		SET		[location_id] 		= @new_location_id,
				[shadow_size_id]	= @new_shadow_size_id
		WHERE 	[Critter_ID]			= @Critter_ID
			AND [location_id] 		= @old_location_id
			AND [shadow_size_id] 	= @old_shadow_size_id
				
	END
GO

print '' print '*** sp_update_critter ***'
GO
CREATE PROCEDURE [dbo].[sp_update_critter]
(
	@Critter_ID 				[nvarchar](40),
	
	@old_critter_type_id		[nvarchar](16)
	@old_rain_needed			[bit],
	@old_is_in_museum			[bit],
	@old_price					[int],
	@old_museum_by_login_name	[nvarchar](16),
	@old_active					[bit],
	
	@new_critter_type_id		[nvarchar](16)
	@new_rain_needed			[bit],
	@new_is_in_museum			[bit],
	@new_price					[int],
	@new_museum_by_login_name	[nvarchar](16),
	@new_active					[bit]
)
AS
	BEGIN
		UPDATE [critter]
		SET		[rain_needed]			= @new_rain_needed,
				[is_in_museum] 			= @new_is_in_museum,
				[price] 				= @new_price,
				[critter_type_id]		= @new_critter_type_id,
				[museum_by_login_name] 	= @new_museum_by_login_name,
				[active]				= @new_active
		WHERE 	[Critter_ID] 			= @Critter_ID
			AND [rain_needed]			= @old_rain_needed
			AND [is_in_museum]			= @old_is_in_museum
			AND [price]					= @old_price
			AND [museum_by_login_name]	= @old_museum_by_login_name
			AND [active] 				= @old_active
	END
GO
*/

print '' print '*** sp_insert_critter ***'
GO
CREATE PROCEDURE [dbo].[sp_insert_critter]
(
	@critter_id			[nvarchar](40),
	@critter_type_id	[nvarchar](16),
	@rain_needed		[bit],
	@is_in_museum		[bit],
	@price				[int]
)
AS
	BEGIN
		INSERT INTO [dbo].[critter]
			([critter_id],[critter_type_id],[rain_needed],[is_in_museum],[price])
			VALUES
				(@critter_id, @critter_type_id, @rain_needed, @is_in_museum, @price)
	END
GO

print '' print '*** sp_insert_fish ***'
GO
CREATE PROCEDURE [dbo].[sp_insert_fish]
(
	@critter_id			[nvarchar](40),
	@location_id		[nvarchar](40),
	@shadow_size_id		[nvarchar](40)
)
AS
	BEGIN
		INSERT INTO [dbo].[fish]
			([critter_id],[location_id],[shadow_size_id])
			VALUES
				(@critter_id, @location_id, @shadow_size_id)
	END
GO

print '' print '*** sp_insert_bug ***'
GO
CREATE PROCEDURE [dbo].[sp_insert_bug]
(
	@critter_id			[nvarchar](40),
	@spot_id			[nvarchar](40)
)
AS
	BEGIN
		INSERT INTO [dbo].[bug]
			([critter_id],[spot_id])
			VALUES
				(@critter_id, @spot_id)
	END
GO

print '' print '*** sp_insert_sea_creature ***'
GO
CREATE PROCEDURE [dbo].[sp_insert_sea_creature]
(
	@critter_id			[nvarchar](40),
	@movement_id		[nvarchar](40),
	@shadow_size_id		[nvarchar](40)
)
AS
	BEGIN
		INSERT INTO [dbo].[sea_creature]
			([critter_id],[movement_id],[shadow_size_id])
			VALUES
				(@critter_id, @movement_id, @shadow_size_id)
	END
GO

print '' print '*** sp_insert_catchable_month ***'
GO
CREATE PROCEDURE [dbo].[sp_insert_catchable_month]
(
	@critter_id [nvarchar](40),
	@jan		[bit],
	@feb		[bit],
	@mar		[bit],
	@apr		[bit],
	@may		[bit],
	@june		[bit],
	@july		[bit],
	@aug		[bit],
	@sep		[bit],
	@octo		[bit],
	@nov		[bit],
	@dec		[bit]
	
)
AS
	BEGIN
		INSERT INTO [dbo].[catchable_month]
			([critter_id],[jan],[feb],[mar],[apr],[may],[june],[july],[aug],[sep],[octo],[nov],[dec])
			VALUES
				(@critter_id, @jan, @feb, @mar, @apr, @may, @june, @july, @aug, @sep, @octo, @nov, @dec)
	END
GO

print '' print '*** sp_insert_catchable_hour ***'
GO
CREATE PROCEDURE [dbo].[sp_insert_catchable_hour]
(
	@critter_id			[nvarchar](40),
	@hour1am			[bit],
	@hour2am			[bit],
	@hour3am			[bit],
	@hour4am			[bit],
	@hour5am			[bit],
	@hour6am			[bit],
	@hour7am			[bit],
	@hour8am			[bit],
	@hour9am			[bit],
	@hour10am			[bit],
	@hour11am			[bit],
	@hour12pm			[bit],
	@hour1pm			[bit],
	@hour2pm			[bit],
	@hour3pm			[bit],
	@hour4pm			[bit],
	@hour5pm			[bit],
	@hour6pm			[bit],
	@hour7pm			[bit],
	@hour8pm			[bit],
	@hour9pm			[bit],
	@hour10pm			[bit],
	@hour11pm			[bit],
	@hour12am			[bit]
)
AS
	BEGIN
		INSERT INTO [dbo].[catchable_hours]
			([critter_id],[hour1am],[hour2am],[hour3am],[hour4am],[hour5am],[hour6am],[hour7am],[hour8am],[hour9am],[hour10am],[hour11am],[hour12pm],[hour1pm],[hour2pm],[hour3pm],[hour4pm],[hour5pm],[hour6pm],[hour7pm],[hour8pm],[hour9pm],[hour10pm],[hour11pm],[hour12am])
			VALUES
				(@critter_id, @hour1am,@hour2am,@hour3am,@hour4am,@hour5am,@hour6am,@hour7am,@hour8am,@hour9am,@hour10am,@hour11am,@hour12pm,@hour1pm,@hour2pm,@hour3pm,@hour4pm,@hour5pm,@hour6pm,@hour7pm,@hour8pm,@hour9pm,@hour10pm,@hour11pm,@hour12am)
	END
GO

print '' print '*** sp_delete_critter_by_critter ***'
GO
CREATE PROCEDURE [dbo].[sp_delete_critter_by_critter]
(
	@critter_id		 		[nvarchar](40), 		
    @rain_needed 			[bit],				
	@is_in_museum 			[bit], 				
    @price 					[int], 				
    @critter_type_id 		[nvarchar](40),
	@museum_by_login_name	[nvarchar](16),			
	@active					[bit]	
)
AS	
	BEGIN
		DELETE FROM critter
		WHERE 	critter_id = @critter_id
			AND rain_needed = @rain_needed
			AND is_in_museum = @is_in_museum
			AND price = @price
			AND critter_type_id = @critter_type_id
			AND museum_by_login_name = @museum_by_login_name
			AND active = @active
	END
GO

print '' print '*** sp_delete_fish_by_fish ***'
GO
CREATE PROCEDURE [dbo].[sp_delete_fish_by_fish]
(
	@critter_id		 		[nvarchar](40), 		
	@location_id			[nvarchar](40),
	@shadow_size_id			[nvarchar](40)
)
AS	
	BEGIN
		DELETE FROM fish
		WHERE 	critter_id = @critter_id
			AND location_id = @location_id
			AND shadow_size_id = @shadow_size_id
	END
GO

print '' print '*** sp_delete_bug_by_bug ***'
GO
CREATE PROCEDURE [dbo].[sp_delete_bug_by_bug]
(
	@critter_id		 		[nvarchar](40), 		
    @spot_id				[nvarchar](40)	
)
AS	
	BEGIN
		DELETE FROM bug
		WHERE 	critter_id = @critter_id
			AND spot_id = @spot_id
	END
GO

print '' print '*** sp_delete_sea_creature_by_sea_creature ***'
GO
CREATE PROCEDURE [dbo].[sp_delete_sea_creature_by_sea_creature]
(
	@critter_id		 		[nvarchar](40), 		
	@movement_id			[nvarchar](40),
	@shadow_size_id			[nvarchar](40)
)
AS	
	BEGIN
		DELETE FROM sea_creature
		WHERE 	critter_id = @critter_id
			AND movement_id = @movement_id
			AND shadow_size_id = @shadow_size_id
	END
GO

print '' print '*** sp_delete_catchable_month_by_critter_id ***'
GO
CREATE PROCEDURE [dbo].[sp_delete_catchable_month_by_critter_id]
(
	@critter_id [nvarchar](40)
)
AS	
	BEGIN
		DELETE FROM catchable_month
		WHERE 	critter_id = @critter_id
	END
GO

print '' print '*** sp_delete_catchable_hour_by_critter_id ***'
GO
CREATE PROCEDURE [dbo].[sp_delete_catchable_hour_by_critter_id]
(
	@critter_id [nvarchar](40)
)
AS	
	BEGIN
		DELETE FROM catchable_hours
		WHERE 	critter_id = @critter_id
	END
GO

print '' print '*** sp_delete_caught_by_by_critter_id ***'
GO
CREATE PROCEDURE [dbo].[sp_delete_caught_by_by_critter_id]
(
    @critter_id 				[nvarchar](40)
)
AS	
	BEGIN
		DELETE FROM caught_by
		WHERE critter_id = @critter_id
	END
GO

print '' print '*** sp_select_critter_by_critter_id ***'
GO
CREATE PROCEDURE [dbo].[sp_select_critter_by_critter_id](
	@critter_id		[nvarchar](40)
)
AS
	BEGIN
		SELECT [rain_needed], [is_in_museum], [price], [museum_by_login_name], [critter].[critter_type_id], [critter_type].[catch_description], [active]
		FROM [critter] JOIN [critter_type] ON [critter].[critter_type_id] = [critter_type].[critter_type_id]
		WHERE [critter].[critter_id] = @critter_id
	END
GO

print '' print '*** sp_delete_villager_role ***'
GO
CREATE PROCEDURE [dbo].[sp_delete_villager_role]
(
    @villager_id 				[int],
	@role_id					[nvarchar](40)
)
AS	
	BEGIN
		DELETE FROM villager_role
		WHERE villager_id = @villager_id
				AND role_id = @role_id
	END
GO

print '' print '*** sp_insert_villager_role ***'
GO
CREATE PROCEDURE [dbo].[sp_insert_villager_role]
(
    @villager_id 				[int],
	@role_id					[nvarchar](40)
)
AS	
	BEGIN
		INSERT INTO [dbo].[villager_role]
		(
			[villager_id],
			[role_id]
		)
		VALUES
		(
			@villager_id,
			@role_id
		)
	END
GO

print '' print '*** sp_insert_caught_by ***'
GO
CREATE PROCEDURE [dbo].[sp_insert_caught_by]
(
    @villager_id			[int],			
	@critter_id 			[nvarchar](40),
	@caught_date 			[date]			
)
AS	
	BEGIN
		INSERT INTO [dbo].[caught_by]
		(
			[villager_id],
			[critter_id],
			[caught_date]
		)
		VALUES
		(
			@villager_id,
			@critter_id,
			@caught_date
		)
	END
GO

print '' print '*** sp_put_critter_in_museum ***'
GO
CREATE PROCEDURE [dbo].[sp_put_critter_in_museum]
(
	@critter_id 				[nvarchar](40),
	@museum_by_login_name		[nvarchar](16) 
)
AS
	BEGIN
		UPDATE [dbo].[critter]
		SET		[is_in_museum] 			= 1,
				[museum_by_login_name] 	= @museum_by_login_name
		WHERE 	[critter_id] 			= @critter_id
			AND [is_in_museum]			= 0
	END
GO

print '' print '*** sp_remove_critter_from_museum ***'
GO
CREATE PROCEDURE [dbo].[sp_remove_critter_from_museum]
(
	@critter_id 				[nvarchar](40)
)
AS
	BEGIN
		UPDATE [dbo].[critter]
		SET		[is_in_museum] 			= 0,
				[museum_by_login_name] 	= null
		WHERE 	[critter_id] 			= @critter_id
			AND [is_in_museum]			= 1
	END
GO

