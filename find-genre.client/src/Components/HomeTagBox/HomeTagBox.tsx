import { Button, Group, Text, useMantineColorScheme } from "@mantine/core";
import { MinusIcon, PlusIcon } from "@radix-ui/react-icons";
import styles from "./HomeTagBox.module.css";
import React, { useState } from "react";
import { ITagData } from "../../Types/hometag";
interface Props {
  tag: ITagData,
  update: (tag: ITagData, state: string) => void
}

const HomeTagBox = (props: Props) => {
  const { colorScheme, setColorScheme } = useMantineColorScheme();
  const tagBackground = () => {
    if (colorScheme === 'dark'){
      if (props.tag.state === 'include'){
        return styles.include_dark + ' ' + styles.container_padding
      } else if(props.tag.state === 'exclude')return styles.exclude_dark + ' ' + styles.container_padding
    } else {
      if (props.tag.state === 'include'){
        return styles.include_light + ' ' + styles.container_padding
      } else if(props.tag.state==='exclude')return styles.exclude_light + ' ' + styles.container_padding
    }
  }
  const buttonVariant = () => {
    if(colorScheme === 'dark'){
      return 'light'
    } else return 'filled'
  }
  const handleClick = (status: string) => {
    if(status === 'include'){
      props.update(props.tag, 'include')
    } else {
      props.update(props.tag, 'exclude')
    }
  }

  return (
    <>
      <Group justify="space-between" classNames={{root: tagBackground()}}>
        <Button variant={buttonVariant()} color="green" onClick={() => handleClick('include')}><PlusIcon /></Button>
        <Text>{props.tag.value}</Text>
        <Button variant={buttonVariant()} color="red" onClick={() => handleClick('exclude')}><MinusIcon /></Button>
      </Group>
    </>
  );
};

export default HomeTagBox;