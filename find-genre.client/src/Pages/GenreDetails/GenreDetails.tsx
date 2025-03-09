import { Carousel } from '@mantine/carousel';
import { Stack, Group, Title, Box, Badge, Text, useComputedColorScheme, useMantineTheme, Card, Flex, Image } from '@mantine/core';
import styles from '../../Components/SongCard/SongCard.module.css'
import { IGenre } from '../../Types/api';
import { Link, useLocation } from 'react-router-dom';
import '@mantine/carousel/styles.css';
import bc_light from '../../assets/bandcamp-logotype-light-128.png'
import json from '../../data.json'
import { useEffect, useState } from 'react';
function GenreDetails() {
    const data = useLocation()
    const [genre, setGenre] = useState<IGenre>()
    const theme = useMantineTheme();
    const scheme = useComputedColorScheme();
    const bg_color = () => {
        return scheme == 'light' ? theme.colors.gray[3] : theme.colors.dark[8]
    }
    useEffect(() => {
        if (!data.state) {
            const array = json.filter((i) => i.name.toLowerCase() === data.pathname.substring(15).replace("%20", " "))
            setGenre(array[0])
        }
    }, [])
    return (
        <Stack mx={'20%'}>
            <Group justify="center" align="center" wrap="nowrap" mt="64" gap="lg">
                <Stack>
                    <Title order={1}>{genre && genre.name}</Title>
                    <Text>
                        {genre && genre.description_short}
                    </Text>
                    <Box bg={bg_color()} p={8} className={styles.container_radius}>
                        <Title order={3} p={8}>Tags:</Title>
                        <Group bd={"1px gray dashed"} p={8}>
                            {genre && genre.tags.map((element) => (
                                <Badge color="indigo" variant="light" key={element.tagId}>{element.name}</Badge>
                            ))}
                        </Group>
                    </Box>
                    {genre && genre.subgenres?.length != 0 && <Box bg={bg_color()} p={8} className={styles.container_radius}>
                        <Title order={3} p={8}>Subgenres:</Title>
                        <Group bd={"1px gray dashed"} p={8}>
                            {genre.subgenres?.map((element) => (
                                <Badge key={element.subgenreId} color="indigo" variant="light">{element.name}</Badge>
                            ))}
                        </Group>
                    </Box>}
                </Stack>
                {genre && <Box w={500} h={400}>
                    <Carousel withIndicators controlSize={40} slideSize="100%" loop>
                        {genre.examples.map((i) => (<Carousel.Slide key={i}><iframe
                            width="500"
                            height="400"
                            frameBorder="0 0 0 0"
                            loading="lazy"
                            src={`https://www.youtube.com/embed/${i}`}
                            allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
                            referrerPolicy="strict-origin-when-cross-origin"
                        ></iframe></Carousel.Slide>))}
                    </Carousel>
                </Box>}
            </Group>
            <Title order={1}>
                {genre && genre.descriptions[0]}
            </Title>
            <Text>
                {genre && genre.descriptions[1]}
            </Text>
            <Title order={1}>
                Artists
            </Title>
            <Card>
                <Title order={2}>{genre && genre.artists[0].name}</Title>
                <Card.Section className={styles.spotify_border} p={"1em"}>
                    <iframe src={`https://open.spotify.com/embed/artist/${genre && genre.artists[0].spotify}`} width="100%" height="352" frameBorder="0" allow="autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture" loading="lazy"></iframe>
                </Card.Section>
            </Card>
            <Card>
                <Title order={2}>{genre && genre.artists[1].name}</Title>
                <Card.Section className={styles.spotify_border} p={"1em"}>
                    <Flex justify={"center"} align={"center"}>
                        <Link to={`https://${genre && genre.artists[1].bandcamp}.bandcamp.com/`} target={"_blank"}>
                            <Image src={bc_light} width={442} height={128} />
                        </Link>
                    </Flex>
                </Card.Section>
            </Card>
        </Stack>
    );
}

export default GenreDetails;