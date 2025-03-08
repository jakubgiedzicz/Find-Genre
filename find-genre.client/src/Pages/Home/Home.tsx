import { Box, Button, Divider, Stack, Text, TextInput, Title } from "@mantine/core";
import { useState } from "react";
import { MagnifyingGlassIcon } from "@radix-ui/react-icons";
import HomeTagBox from "../../Components/HomeTagBox/HomeTagBox";
import { ITagData } from "../../Types/hometag";
import ReloadSearch from "../../Components/ReloadSearch/ReloadSearch";
import { Form } from "react-router-dom";

function Home() {
    const [value, setValue] = useState("");
    const [tags, setTags] = useState<ITagData[]>([
        { value: "cheerful", id: 11, state: "default" },
        { value: "choir", id: 3, state: "default" },
        { value: "classic", id: 13, state: "default" },
        { value: "club", id: 6, state: "default" },
        { value: "dark", id: 1, state: "default" },
        { value: "electronic", id: 2, state: "default" },
        { value: "european", id: 16, state: "default" },
        { value: "fast", id: 9, state: "default" },
        { value: "korean", id: 15, state: "default" },
        { value: "niche", id: 5, state: "default" },
        { value: "old", id: 12, state: "default" },
        { value: "popular", id: 4, state: "default" },
        { value: "slow", id: 10, state: "default" },
        { value: "solitude", id: 7, state: "default" },
        { value: "tiktok", id: 8, state: "default" },
        { value: "western", id: 14, state: "default" },
    ]);
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
    return (
        <>
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
                        onChange={(event) => setValue(event.currentTarget.value)}
                        rightSection={<ReloadSearch handleReload={handleReload} />}
                        leftSection={<MagnifyingGlassIcon width={20} height={20} />}
                    />
                    <Form action={"/search"} name={"q"} method={"get"}>
                        <input name="include" type="text" hidden={true} value={"cheerful tiktok"} readOnly />
                        <input name="exclude" type="text" hidden={true} value={"western"} readOnly />
                        <Button type={"submit"}>Search</Button>
                    </Form>
                    <Divider my="sm" />
                    {tags.map(
                        (tag) =>
                            tag.state === "include" && (
                                <HomeTagBox tag={tag} update={updateTag} key={"1" + tag.id} />
                            )
                    )}
                    {tags.map(
                        (tag) =>
                            tag.state === "exclude" && (
                                <HomeTagBox tag={tag} update={updateTag} key={"1" + tag.id} />
                            )
                    )}
                    {tags.map(
                        (tag) =>
                        (tag.value.includes(value) && tag.state === "default" && (
                            <HomeTagBox tag={tag} update={updateTag} key={"0" + tag.id} />
                        ))
                    )}
                </Stack>
            </Stack>
        </>
    );
}

export default Home;
