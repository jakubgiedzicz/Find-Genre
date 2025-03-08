import { useSearchParams } from "react-router-dom";
import { IGenre } from "../../Types/api";
import { Badge, Card, Group, Stack, Text, Title, useComputedColorScheme } from "@mantine/core";
const example: IGenre = {
    name: "Witch House",
    description: "Witch house is a microgenre of electronic music that is musically characterized by high-pitched keyboard effects, heavily layered basslines and trap-style drum loops, while it aesthetically employs occult and gothic-inspired themes.",
    tags: [{ name: "Slow", tagId: 1 }, { name: "cheerful", tagId: 2 }, { name: "choir", tagId: 3 }, { name: "classic", tagId: 4 }, { name: "club", tagId: 5 }, { name: "dark", tagId: 6 }, { name: "Eerie", tagId: 7 }, { name: "Eerie", tagId: 8 }, { name: "Eerie", tagId: 9 }, { name: "Eerie", tagId: 10 }, { name: "Eerie", tagId: 11 }, { name: "Eerie", tagId: 12 }, { name: "Eerie", tagId: 13 }, { name: "Eerie", tagId: 142 }, { name: "Eerie", tagId: 152 }],
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
function SearchResult() {
    const [searchParams, setSearchParams] = useSearchParams()
    const scheme = useComputedColorScheme()
    const getTags = () => {
        return example.tags.map((e) => {
            if (searchParams.get("include")?.split(" ").includes(e.name)) {
                return (<Badge key={e.tagId} color="green" variant={scheme == "dark" ? "light" : "filled"}>{e.name}</Badge>)
            } else return (<Badge key={e.tagId} color="indigo" variant={scheme == "dark" ? "light" : "filled"}>{e.name}</Badge>)
        })
    }
    return (
        <Stack mx={"15%"}>
            <Group>
                <Card w="30%" p={64}>
                    <Card.Section pb={16 }>
                        <Title>{example.name}</Title>
                        <Text c="dimmed">{example.description}</Text>
                    </Card.Section>
                    <Card.Section>
                        <Group>
                            {getTags()}
                        </Group>
                    </Card.Section>
                </Card>
                
            </Group>
        </Stack>
  );
}

export default SearchResult;