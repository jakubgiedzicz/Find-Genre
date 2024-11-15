import {
  Box,
  Button,
  Divider,
  Flex,
  Grid,
  InputBase,
  Pill,
  Stack,
  Text,
  TextInput,
  Title,
} from "@mantine/core";
import { useEffect, useState } from "react";
import { MagnifyingGlassIcon } from "@radix-ui/react-icons";
import HomeTagBox from "../../Components/HomeTagBox/HomeTagBox";
import { ITagData } from "../../Types/hometag";

function Home() {
  const icon = <MagnifyingGlassIcon />;
  const [value, setValue] = useState("");
  const [tags, setTags] = useState<ITagData[]>([
    { value: "dark", id: 1, state: 'default' },
    { value: "electronic", id: 2, state: 'default' },
    { value: "choir", id: 3, state: 'default' },
    { value: "popular", id: 4, state: 'default' },
    { value: "niche", id: 5, state: 'default' },
    { value: "club", id: 6, state: 'default' },
    { value: "solitude", id: 7, state: 'default' },
    { value: "tiktok", id: 8, state: 'default' },
    { value: "fast", id: 9, state: 'default' },
    { value: "slow", id: 10, state: 'default' },
    { value: "cheerful", id: 11, state: 'default' },
    { value: "old", id: 12, state: 'default' },
    { value: "classic", id: 13, state: 'default' },
    { value: "western", id: 14, state: 'default' },
    { value: "korean", id: 15, state: 'default' },
    { value: "european", id: 16, state: 'default' },
  ]);
  const updateTag = (tag: ITagData, state: string) => {
    const newTags = [...tags]
    const update = newTags.find(
      a => a.id === tag.id
    )
    update!.state = state
    setTags(newTags)
  }
  return (
    <>
      <Stack pt="4em" align="center">
        <Box>
          <Title ta="center">Search by tags</Title>
          <Text ta="center">
            Type in words that describe the music you're looking for
          </Text>
        </Box>
        <Stack miw={350} gap="sm">
          <TextInput
            placeholder="Search for tags"
            value={value}
            onChange={(event) => setValue(event.currentTarget.value)}
            rightSection={icon}
          />
          <Divider my="sm" />
          {tags.slice(0, 8).map((tag) => (
            <HomeTagBox tag={tag} update={updateTag}/>
          ))}
        </Stack>
      </Stack>
    </>
  );
}

export default Home;
