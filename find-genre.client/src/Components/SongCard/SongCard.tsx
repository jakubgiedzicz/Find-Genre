import { Title, Text, Pill, InputBase, Stack, Center, Group, Badge, Box, Image, Container, useMantineTheme, useComputedColorScheme, Card, Flex } from "@mantine/core";
import { genreType } from "../../Types/api";
import { useEffect, useState } from "react";
import { Carousel } from "@mantine/carousel";
import '@mantine/carousel/styles.css';
import styles from './SongCard.module.css'
import { Link } from "react-router-dom";
import bc_light from '../../assets/bandcamp-logotype-light-128.png'
function SongCard({ props }: { props: genreType }) {
    const theme = useMantineTheme();
    const scheme = useComputedColorScheme();
    const bg_color = () => {
        return scheme == 'light' ? theme.colors.gray[3] : theme.colors.dark[8]
    }
    return (
        <Stack mx={'20%'}>
            <Group justify="center" align="center" wrap="nowrap" mt="64" gap="lg">
                <Stack>
                    <Title order={1}>{props.name}</Title>
                    <Text>
                        {props.description}
                    </Text>
                    <Box bg={bg_color()} p={8} className={styles.container_radius}>
                        <Title order={3} p={8}>Tags:</Title>
                        <Group bd={"1px gray dashed"} p={8}>
                            {props.tags.map((element) => (
                                <Badge color="indigo" variant="light" key={element.tagId}>{element.name}</Badge>
                            ))}
                        </Group>
                    </Box>
                    {props.subgenres?.length != 0 && <Box bg={bg_color()} p={8} className={styles.container_radius}>
                        <Title order={3} p={8}>Subgenres:</Title>
                        <Group bd={"1px gray dashed"} p={8}>
                            {props.subgenres?.map((element) => (
                                <Badge key={element.subgenreId} color="indigo" variant="light">{element.name}</Badge>
                            ))}
                        </Group>
                    </Box>}
                </Stack>
                <Box w={500} h={400}>
                    <Carousel withIndicators controlSize={40} slideSize="100%" loop>
                        {props.examples.map((i) => (<Carousel.Slide key={i}><iframe
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
            <Title order={1}>
                Aesthetic
            </Title>
            <Text>
                The witch house visual aesthetic includes occultism, witchcraft, shamanism, terror and horror-inspired artworks, collages and photographs. Common typographic elements in titles, such as by Salem and White Ring, include triangles, crosses and Unicode symbols, which are seen by some as a method of gatekeeping (in an effort to keep the scene underground and more difficult to search for on the Internet).
            </Text>
            <Title order={1 }>
            Artists
            </Title>
            <Card>
                <Title order={2}>ΔXIUS LIИK</Title>
                <Card.Section className={styles.spotify_border} p={"1em"}>
                    <iframe src="https://open.spotify.com/embed/artist/1C6yCV9Y7kycveSPJr0un9?utm_source=generator&theme=0" width="100%" height="352" frameBorder="0" allowfullscreen="" allow="autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture" loading="lazy"></iframe>
                </Card.Section>
            </Card>
            <Card>
                <Title order={2}>Fraunhofer Diffraction</Title>
                <Card.Section className={styles.spotify_border} p={"1em"}>
                    <Flex justify={"center"} align={"center"}>
                        <Link to="https://ivoryrite.bandcamp.com/" target={"_blank"}>
                            <Image src={bc_light} width={442} height={128} />
                        </Link>
                    </Flex>
                </Card.Section>
            </Card>
        </Stack>
    );
}

export default SongCard;
