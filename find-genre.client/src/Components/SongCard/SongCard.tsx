import { Title, Text, Pill, InputBase } from "@mantine/core";

function SongCard() {
    const pills = ["Dark", "Electronic"]
    return (
        <>
            <Title order={1}>Witch house</Title>
            <Text>Witch house is a microgenre of electronic music that is musically characterized by high-pitched keyboard effects, heavily layered basslines and trap-style drum loops, while it aesthetically employs occult and gothic-inspired themes.</Text>
            <iframe width="500"
                    height="400"
                    src="https://www.youtube.com/embed/S40KVjsdCCM"
                    title="± River Bones - Tyrant ±"
                    allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
                    referrerPolicy="strict-origin-when-cross-origin">
            </iframe>
            <Title order={3}>Tags:</Title>
            <InputBase component="div" multiline>
                <Pill.Group>
                    {pills.map((element) => <Pill>{element}</Pill>)}
                </Pill.Group>
            </InputBase>
        </>
    );
}

export default SongCard;