import { Carousel } from '@mantine/carousel';
import { Stack, Group, Title, Box, Badge, Text, useComputedColorScheme, useMantineTheme } from '@mantine/core';
import styles from '../../Components/SongCard/SongCard.module.css'
import { IGenre } from '../../Types/api';
const example: IGenre = {
    name: "Witch House",
    description: "Witch house is a microgenre of electronic music that is musically characterized by high-pitched keyboard effects, heavily layered basslines and trap-style drum loops, while it aesthetically employs occult and gothic-inspired themes.",
    tags: [{ name: "Slow", tagId: 1 }, { name: "Eerie", tagId: 2 }, { name: "Eerie", tagId: 3 }, { name: "Eerie", tagId: 4 }, { name: "Eerie", tagId: 5 }, { name: "Eerie", tagId: 6 }, { name: "Eerie", tagId: 7 }, { name: "Eerie", tagId: 8 }, { name: "Eerie", tagId: 9 }, { name: "Eerie", tagId: 10 }, { name: "Eerie", tagId: 11 }, { name: "Eerie", tagId: 12 }, { name: "Eerie", tagId: 13 }, { name: "Eerie", tagId: 142 }, { name: "Eerie", tagId: 152 }],
    examples: [
        "0YxnPvRuJXk",
        "k6t69KQOBCg",
        "xiCEzJIDpwU",
        "TUFN4R2jb30",
        "OM6o0y3NYcQ"],
    genreId: 1,
    popularity: 0,
    promoted: [""]
}
function GenreDetails() {
    const theme = useMantineTheme();
    const scheme = useComputedColorScheme();
    const bg_color = () => {
        return scheme == 'light' ? theme.colors.gray[3] : theme.colors.dark[8]
    }
    return (
        <Stack mx={'20%'}>
            <Group justify="center" align="flex-start" wrap="nowrap" mt="64" gap="lg">
                <Stack>
                    <Title order={1}>{example.name}</Title>
                    <Text>
                        {example.description}
                    </Text>
                    <Box bg={bg_color()} p={8} className={styles.container_radius}>
                        <Title order={3} p={8}>Tags:</Title>
                        <Group bd={"1px gray dashed"} p={8}>
                            {example.tags.map((element) => (
                                <Badge color="indigo" variant="light" key={element.tagId}>{element.name}</Badge>
                            ))}
                        </Group>
                    </Box>
                    {example.subgenres?.length != 0 && <Box bg={bg_color()} p={8} className={styles.container_radius}>
                        <Title order={3} p={8}>Subgenres:</Title>
                        <Group bd={"1px gray dashed"} p={8}>
                            {example.subgenres?.map((element) => (
                                <Badge key={element.subgenreId} color="indigo" variant="light">{element.name}</Badge>
                            ))}
                        </Group>
                    </Box>}
                </Stack>
                <Box w={500} h={400}>
                    <Carousel withIndicators controlSize={40} slideSize="100%" loop>
                        {example.examples.map((i) => (<Carousel.Slide key={i}><iframe
                            width="500"
                            height="400"
                            frameBorder="0 0 0 0"
                            loading="lazy"
                            src={`https://www.youtube.com/embed/${i}`}
                            allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
                            referrerPolicy="strict-origin-when-cross-origin"
                        ></iframe></Carousel.Slide>))}
                    </Carousel>
                </Box>
            </Group>
        </Stack>
  );
}

export default GenreDetails;