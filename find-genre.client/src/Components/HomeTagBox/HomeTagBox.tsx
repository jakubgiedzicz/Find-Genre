import { Button, Group, Text, useMantineColorScheme } from "@mantine/core";
import { MinusIcon, PlusIcon } from "@radix-ui/react-icons";
import styles from "./HomeTagBox.module.css";
import React, { useState } from "react";
interface Props {
  name: string
}

const HomeTagBox = (props: Props) => {
  const { colorScheme, setColorScheme } = useMantineColorScheme();
  //true stands for tag = included, false = exclude tag in search
  const [tagStatus, setTagStatus] = useState(true)
  const tagBackground = () => {
    if (colorScheme === 'dark'){
      if (tagStatus === true){
        return styles.include_dark + ' ' + styles.container_padding
      } else return styles.exclude_dark + ' ' + styles.container_padding
    } else {
      if (tagStatus === true){
        return styles.include_light + ' ' + styles.container_padding
      } else return styles.exclude_light + ' ' + styles.container_padding
    }
  }
  const buttonVariant = () => {
    if(colorScheme === 'dark'){
      return 'light'
    } else return 'filled'
  }
  const handleClick = (status: boolean) => {
    if(status === true){
      setTagStatus(true)
    } else {
      setTagStatus(false)
    }
  }

  return (
    <>
      <Group justify="space-around" classNames={{root: tagBackground()}}>
        <Button variant={buttonVariant()} color="green" onClick={() => handleClick(true)}><PlusIcon /></Button>
        <Text>{props.name}</Text>
        <Button variant={buttonVariant()} color="red" onClick={() => handleClick(false)}><MinusIcon /></Button>
      </Group>
    </>
  );
};

export default HomeTagBox;