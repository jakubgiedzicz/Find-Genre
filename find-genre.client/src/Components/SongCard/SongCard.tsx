import { Title, Text, Pill, InputBase, Stack, Center, Group, Badge, Box, Image } from "@mantine/core";
import { genreType } from "../../Types/api";
import { useEffect, useState } from "react";
import { Carousel } from "@mantine/carousel";
import '@mantine/carousel/styles.css';
function SongCard({ props }: { props: genreType }) {
    const [link, setLink] = useState(1)
    useEffect(() => {
        if (link >= props.examples.length) {
            setLink(0)
        } else if (link <= -1) {
            setLink(props.examples.length - 1)
        }
    }, [link])
    return (
        <Stack mx={'20%'}>
            <Group justify="center" align="flex-start" wrap="nowrap" mt="64" gap="lg">
                <Stack>
                    <Title order={1}>{props.name}</Title>
                <Text>
                    {props.description}
                    </Text>
                    <Title order={3}>Tags:</Title>
                    <Group>
                        {props.tags.map((element) => (
                            <Badge color="indigo" variant="light" key={element.tagId}>{element.name}</Badge>
                        ))}
                    </Group>
                    {props.subgenres.length!=0 && <Box>
                        <Title order={3}>Subgenres:</Title>
                        {props.subgenres.map((element) => (
                            <Badge key={element.subgenreId} color="indigo" variant="light">{element.name}</Badge>
                        ))}
                    </Box>}
                </Stack>
                <Box w={500} h={ 400}>
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
        </Stack>
    );
}

export default SongCard;
