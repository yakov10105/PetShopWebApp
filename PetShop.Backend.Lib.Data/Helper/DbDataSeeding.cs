using Microsoft.EntityFrameworkCore;
using PetShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Backend.Lib.Data.Helper
{
    public static class DbDataSeeding
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 2, CategoryName = "Mammal" ,Animals=new List<Animal>() },
                new Category { CategoryId = 3, CategoryName = "Reptiles", Animals = new List<Animal>() },
                new Category { CategoryId = 4, CategoryName = "Bird", Animals = new List<Animal>() }
            );
            modelBuilder.Entity<Animal>().HasData(
                new Animal
                {
                    AnimalId = 1,
                    Name = "Dog",
                    CategoryId = 2,
                    Age = 10,
                    Description = "The domestic dog (Canis familiaris or Canis lupus familiaris)[4] is a domesticated descendant of the wolf. The dog derived from an ancient, extinct wolf,[5][6] and the modern grey wolf is the dog's nearest living relative.[7] The dog was the first species to be domesticated,[8][7] by hunter–gatherers over 15,000 years ago,[6] before the development of agriculture.[1] Their long association with humans has led dogs to be uniquely adapted to human behavior,[9] leading to a large number of domestic individuals[10] and the ability to thrive on a starch-rich diet that would be inadequate for other canids.[11]",
                    PictureName = "/Assets/AnimalImgs/dog.jpg",
                    Comments = new List<Comment>()
                },
                new Animal
                {
                    AnimalId = 2,
                    Name = "Cat",
                    CategoryId = 2,
                    Age = 3,
                    Description = "The cat (Felis catus) is a domestic species of small carnivorous mammal.[1][2] It is the only domesticated species in the family Felidae and is often referred to as the domestic cat to distinguish it from the wild members of the family.[4] A cat can either be a house cat, a farm cat or a feral cat; the latter ranges freely and avoids human contact.[5] Domestic cats are valued by humans for companionship and their ability to hunt rodents. About 60 cat breeds are recognized by various cat registries.[6]",
                    PictureName = "/Assets/AnimalImgs/cat.jpg",
                    Comments = new List<Comment>()
                },
                new Animal
                {
                    AnimalId = 3,
                    Name = "Hamster",
                    CategoryId = 2,
                    Age = 1,
                    Description = "Hamsters are rodents (order Rodentia) belonging to the subfamily Cricetinae, which contains 19 species classified in seven genera.[1][2] They have become established as popular small pets.[3] The best-known species of hamster is the golden or Syrian hamster (Mesocricetus auratus), which is the type most commonly kept as pets. Other hamster species commonly kept as pets are the three species of dwarf hamster, Campbell's dwarf hamster (Phodopus campbelli), the winter white dwarf hamster (Phodopus sungorus) and the Roborovski hamster (Phodopus roborovskii).",
                    PictureName = "/Assets/AnimalImgs/hamster.jpg",
                    Comments = new List<Comment>()
                },
                new Animal
                {
                    AnimalId = 4,
                    Name = "Snake",
                    CategoryId = 3,
                    Age = 3,
                    Description = "Snakes are elongated, limbless, carnivorous reptiles of the suborder Serpentes /sɜːrˈpɛntiːz/.[2] Like all other squamates, snakes are ectothermic, amniote vertebrates covered in overlapping scales. Many species of snakes have skulls with several more joints than their lizard ancestors, enabling them to swallow prey much larger than their heads with their highly mobile jaws. To accommodate their narrow bodies, snakes' paired organs (such as kidneys) appear one in front of the other instead of side by side, and most have only one functional lung. Some species retain a pelvic girdle with a pair of vestigial claws on either side of the cloaca. Lizards have evolved elongate bodies without limbs or with greatly reduced limbs about twenty-five times independently via convergent evolution, leading to many lineages of legless lizards.[3] These resemble snakes, but several common groups of legless lizards have eyelids and external ears, which snakes lack, although this rule is not universal (see Amphisbaenia, Dibamidae, and Pygopodidae).",
                    PictureName = "/Assets/AnimalImgs/snake.jpg",
                    Comments = new List<Comment>()
                },
                new Animal
                {
                    AnimalId = 5,
                    Name = "Chameleon",
                    CategoryId = 3,
                    Age = 2,
                    Description = "Chameleons or chamaeleons (family Chamaeleonidae) are a distinctive and highly specialized clade of Old World lizards with 202 species described as of June 2015.[1] These species come in a range of colors, and many species have the ability to change color.",
                    PictureName = "/Assets/AnimalImgs/chameleon.jpg",
                    Comments = new List<Comment>()
                },
                new Animal
                {
                    AnimalId = 6,
                    Name = "Lizard",
                    CategoryId = 3,
                    Age = 5,
                    Description = "Lizards are a widespread group of squamate reptiles, with over 6,000 species,[1] ranging across all continents except Antarctica, as well as most oceanic island chains. The group is paraphyletic as it excludes the snakes and Amphisbaenia; some lizards are more closely related to these two excluded groups than they are to other lizards. Lizards range in size from chameleons and geckos a few centimeters long to the 3 meter long Komodo dragon.",
                    PictureName = "/Assets/AnimalImgs/lizard.jpg",
                    Comments = new List<Comment>()
                },
                new Animal
                {
                    AnimalId = 7,
                    Name = "Parrot",
                    CategoryId = 4,
                    Age = 15,
                    Description = "Parrots, also known as psittacines /ˈsɪtəsaɪnz/,[1][2] are birds of the roughly 398 species[3] in 92 genera comprising the order Psittaciformes /ˈsɪtəsɪfɔːrmiːz/, found mostly in tropical and subtropical regions. The order is subdivided into three superfamilies: the Psittacoidea, the Cacatuoidea (cockatoos), and the Strigopoidea (New Zealand parrots). One-third of all parrot species are threatened by extinction, with higher aggregate extinction risk (IUCN Red List Index) than any other comparable bird group.[4] Parrots have a generally pantropical distribution with several species inhabiting temperate regions in the Southern Hemisphere, as well. The greatest diversity of parrots is in South America and Australasia.",
                    PictureName = "/Assets/AnimalImgs/parrot.jpg",
                    Comments = new List<Comment>()
                },
                new Animal
                {
                    AnimalId = 8,
                    Name = "Cackatoo",
                    Age = 15,
                    CategoryId = 4,
                    Description = "A cockatoo is any of the 21 parrot species belonging to the family Cacatuidae, the only family in the superfamily Cacatuoidea. Along with the Psittacoidea (true parrots) and the Strigopoidea (large New Zealand parrots), they make up the order Psittaciformes. The family has a mainly Australasian distribution, ranging from the Philippines and the eastern Indonesian islands of Wallacea to New Guinea, the Solomon Islands and Australia.",
                    PictureName = "/Assets/AnimalImgs/cackatoo.png",
                    Comments = new List<Comment>()
                },
                new Animal
                {
                    AnimalId = 9,
                    Name = "Lovebird",
                    Age = 4,
                    CategoryId = 4,
                    Description = "Lovebird is the common name for the genus Agapornis, a small group of parrots in the Old World parrot family Psittaculidae. Of the nine species in the genus, eight are native to the African continent, with the grey-headed lovebird being native to Madagascar.",
                    PictureName = "/Assets/AnimalImgs/lovebird.jpg",
                    Comments = new List<Comment>()
                }

            ) ;
            modelBuilder.Entity<Comment>().HasData(
                new Comment { CommentId = 1, CommentInfo = "Beautiful !", AnimalId = 1, WriterName = "John123", Date = DateTime.Now },
                new Comment { CommentId = 2, CommentInfo = "Gorgeous !", AnimalId = 2, WriterName = "Yossi", Date = DateTime.Now },
                new Comment { CommentId = 3, CommentInfo = "Wow!", AnimalId = 6, WriterName = "Anna000", Date = DateTime.Now },
                new Comment { CommentId = 4, CommentInfo = "So Cute !", AnimalId = 1, WriterName = "Pedro77", Date = DateTime.Now },
                new Comment { CommentId = 5, CommentInfo = "Scary !", AnimalId = 6, WriterName = "Yakov10105", Date = DateTime.Now }
            ) ;
        }
    }
}
