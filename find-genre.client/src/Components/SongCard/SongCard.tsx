import { Title, Text, Pill, InputBase, Stack } from "@mantine/core";
import { genreType } from "../../Types/api";
import { useState } from "react";
function SongCard({ props }: { props: genreType }) {
    return (
        <Stack mx={'20%'}>
            <Title order={1}>{props.name}</Title>
            <Text>
                {props.description}
            </Text>
            <iframe
                width="500"
                height="400"
                src="https://www.youtube.com/embed/S40KVjsdCCM"
                title="� River Bones - Tyrant �"
                allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
                referrerPolicy="strict-origin-when-cross-origin"
            ></iframe>
            <Title order={3}>Tags:</Title>
            <InputBase component="div" multiline>
                <Pill.Group>
                    {props.tags.map((element) => (
                        <Pill key={element.tagId}>{element.name}</Pill>
                    ))}
                </Pill.Group>
            </InputBase>
            <Title order={3}>Subgenres:</Title>
            <InputBase component="div" multiline>
                <Pill.Group>
                    {props.subgenres.map((element) => (
                        <Pill key={element.subgenreId}>{element.name}</Pill>
                    ))}
                </Pill.Group>
            </InputBase>
        </Stack>
    );
}

export default SongCard;
