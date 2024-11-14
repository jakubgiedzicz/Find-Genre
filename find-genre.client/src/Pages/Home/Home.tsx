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
import classes from "./Home.module.css";
import HomeTagBox from "../../Components/HomeTagBox/HomeTagBox";
interface ITagData {
  value: string;
  disabled: boolean;
}
interface ITagState extends ITagData {
  id: number;
}

function Home() {
  const icon = <MagnifyingGlassIcon />;
  const [count, setCount] = useState(1);
  const [value, setValue] = useState("");
  const [required, setRequired] = useState<ITagState[]>([]);
  const [optional, setOptional] = useState<ITagState[]>([]);
  const [exclude, setExclude] = useState<ITagState[]>([]);
  const tagsL = [
    "dark",
    "electronic",
    "choir",
    "popular",
    "niche",
    "club",
    "solitude",
    "tiktok",
    "fast",
    "slow",
    "cheerful",
    "old",
    "classic",
    "western",
    "korean",
    "european",
  ];
  const [dataR, setDataR] = useState<ITagData[]>([
    { value: "React", disabled: false },
    { value: "Angular", disabled: false },
    { value: "Vue", disabled: false },
    { value: "Svelte", disabled: false },
  ]);
  return (
    <>
      <Stack pt="4em" align="center">
        <Box>
          <Title ta="center">Search by tags</Title>
          <Text ta="center">
            Type in words that describe the music you're looking for
          </Text>
        </Box>
        <Stack miw={350} gap='sm'>
            <TextInput
              placeholder="Search for tags"
              value={value}
              onChange={(event) => setValue(event.currentTarget.value)}
              rightSection={icon}
            />
            <Divider my="sm"/>
            <HomeTagBox name={tagsL[1]}/>
        </Stack>
      </Stack>
    </>
  );
}

export default Home;
