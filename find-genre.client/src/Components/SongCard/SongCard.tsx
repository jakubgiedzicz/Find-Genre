import { Title, Text, Pill, InputBase, Stack, Center } from "@mantine/core";
import { genreType } from "../../Types/api";
import { useEffect, useState } from "react";
import { Carousel } from "@mantine/carousel";
import '@mantine/carousel/styles.css';
function SongCard({ props }: { props: genreType }) {
    const [link, setLink] = useState(0)
    useEffect(() => {
        if (link >= props.examples.length) {
            setLink(0)
        } else if (link <= -1) {
            setLink(props.examples.length - 1)
        }
    }, [link])
    return (
        <Stack mx={'20%'}>
            {link}
            <Title order={1}>{props.name}</Title>
            <Text>
                {props.description}
            </Text>
            <Center>
                <Carousel withIndicators loop onNextSlide={() => setLink(prev => prev + 1)} onPreviousSlide={() => setLink(prev => prev - 1)}>
                    <Carousel.Slide><iframe
                        width="500"
                        height="400"
                        src={`https://www.youtube.com/embed/${props.examples[link]}`}
                        allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
                        referrerPolicy="strict-origin-when-cross-origin"
                    ></iframe></Carousel.Slide>
                </Carousel>
            </Center>
            <Title order={3}>Tags:</Title>
            <Pill.Group>
                {props.tags.map((element) => (
                    <Pill key={element.tagId}>{element.name}</Pill>
                ))}
            </Pill.Group>
            <Title order={3}>Subgenres:</Title>
            <Pill.Group>
                {props.subgenres.map((element) => (
                    <Pill key={element.subgenreId}>{element.name}</Pill>
                ))}
            </Pill.Group>
        </Stack>
    );
}

export default SongCard;
