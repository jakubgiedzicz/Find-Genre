import { Button, Group, Text } from "@mantine/core";
import React from "react";
interface Props {
  name: string
}

const HomeTagBox = (props: Props) => {
  return (
    <>
      <Group justify="center">
        <Button>+</Button>
        <Text>{props.name}</Text>
        <Button>-</Button>
      </Group>
    </>
  );
};

export default HomeTagBox;