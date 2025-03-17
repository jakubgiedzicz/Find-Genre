import { Alert, Box, Button, Divider, Flex, Stack, Text, TextInput, Title, Tooltip } from "@mantine/core";
import { useEffect, useState } from "react";
import { MagnifyingGlassIcon } from "@radix-ui/react-icons";
import HomeTagBox from "../../Components/HomeTagBox/HomeTagBox";
import { ITagData } from "../../Types/hometag";
import ReloadSearch from "../../Components/ReloadSearch/ReloadSearch";
import SearchForm from "../../Components/SearchForm/SearchForm";
import { InfoCircledIcon } from '@radix-ui/react-icons'

function Home() {
    const [value, setValue] = useState("");
    const [tags, setTags] = useState<ITagData[]>([
        { value: "Fast", id: 11, state: "default" },
        { value: "Slow", id: 3, state: "default" },
        { value: "Aggressive", id: 13, state: "default" },
        { value: "Mysterious", id: 6, state: "default" },
        { value: "Dark", id: 1, state: "default" },
        { value: "Electronic", id: 2, state: "default" },
        { value: "Angry", id: 16, state: "default" },
        { value: "Artificial", id: 9, state: "default" },
        { value: "Basic", id: 29, state: "default" },
        { value: "Beautiful", id: 5, state: "default" },
        { value: "Blissful", id: 12, state: "default" },
        { value: "Bouncy", id: 4, state: "default" },
        { value: "Breathtaking", id: 10, state: "default" },
        { value: "Solitude", id: 7, state: "default" },
        { value: "Calm", id: 8, state: "default" },
        { value: "Cheerful", id: 14, state: "default" },
        { value: "Cinematic", id: 15, state: "default" },
        { value: "Cold", id: 28, state: "default" },
        { value: "Creepy", id: 17, state: "default" },
        { value: "Demonic", id: 18, state: "default" },
        { value: "Divine", id: 19, state: "default" },
        { value: "Easy", id: 20, state: "default" },
        { value: "Eerie", id: 21, state: "default" },
        { value: "Happy", id: 23, state: "default" },
        { value: "Heavy", id: 24, state: "default" },
        { value: "Instrumental", id: 25, state: "default" },
        { value: "Melodic", id: 26, state: "default" },
        { value: "Sad", id: 27, state: "default" },
    ]);
    const [include, setInclude] = useState<string>()
    const [exclude, setExclude] = useState<string>()

    const updateTag = (tag: ITagData, state: "default" | "include" | "exclude") => {
        const newTags = [...tags];
        const update = newTags.find((a) => a.id === tag.id);
        update!.state = state;
        setTags(newTags);
    };
    const handleReload = () => {
        const newTags: ITagData[] = tags.map((tag) => ({
            value: tag.value,
            id: tag.id,
            state: "default",
        }));
        setTags(newTags);
    };
    const handleSearchParams = () => {
            setInclude(tags.filter((i) => i.state == "include").map(o => o.value).join(" "))
            setExclude(tags.filter((i) => i.state == "exclude").map(o => o.value).join(" "))
    }
    const sortedTags = () => {
        const included: JSX.Element[] = []
        const excluded: JSX.Element[] = []
        const defaults: JSX.Element[] = []
        tags.forEach((i) => {
            if (i.state === "default" && i.value.toLowerCase().includes(value.toLowerCase())) {
                defaults.push(<HomeTagBox tag={i} update={updateTag} key={i.id} />)
            } else if (i.state === "include" && i.value.toLowerCase().includes(value.toLowerCase())) {
                included.push(<HomeTagBox tag={i} update={updateTag} key={i.id} />)
            } else if (i.state === "exclude" && i.value.toLowerCase().includes(value.toLowerCase())) {
                excluded.push(<HomeTagBox tag={i} update={updateTag} key={i.id} />)
            }
        })
        return [...included, ...excluded, ...defaults]
    }
    useEffect(() => {
        handleSearchParams()
    }, [tags])
    return (
        <>
            <Flex justify="flex-end" mx="1%">
                <Alert variant="light" color="grape" title="WIP" icon={<InfoCircledIcon />}>
                    This is a work in progress, only test data exists (genres with "Electronic" tag)
                </Alert>
            </Flex>
            <Stack pt="4em" align="center">
                <Box>
                    <Title ta="center">Search by tags</Title>
                    <Text ta="center" fw={500}>
                        Type in words that describe the music you're looking for
                    </Text>
                </Box>
                <Stack miw={350} gap="sm">
                    <TextInput
                        placeholder="Search for tags"
                        value={value}
                        type="text"
                        onChange={(event) => setValue(event.currentTarget.value)}
                        rightSection={<ReloadSearch handleReload={handleReload} />}
                        leftSection={<MagnifyingGlassIcon width={20} height={20} />}
                    />
                    <Stack align="center">
                        {(include || exclude) ? < SearchForm include={include} exclude={exclude} /> : <Tooltip label={"Choose tags to enable search!"}><Button disabled px={64} variant="filled" color="indigo" mt={16}>Find genres</Button></Tooltip>}
                    </Stack>
                    <Divider my="sm" />
                    {sortedTags()}
                </Stack>
            </Stack>
        </>
    );
}

export default Home;
