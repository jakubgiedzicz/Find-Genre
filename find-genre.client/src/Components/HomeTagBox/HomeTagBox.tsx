import { Button, Group, Text, useMantineColorScheme } from "@mantine/core";
import { MinusIcon, PlusIcon } from "@radix-ui/react-icons";
import styles from "./HomeTagBox.module.css";
import { ITagData } from "../../Types/hometag";
interface Props {
    tag: ITagData;
    update: (tag: ITagData, state: string) => void;
}

const HomeTagBox = (props: Props) => {
    const { colorScheme, setColorScheme } = useMantineColorScheme();
    const tagBackground = () => {
        if (colorScheme === "dark") {
            if (props.tag.state === "include") {
                return styles.include_dark;
            } else if (props.tag.state === "exclude")
                return styles.exclude_dark;
        } else {
            if (props.tag.state === "include") {
                return styles.include_light;
            } else if (props.tag.state === "exclude")
                return styles.exclude_light;
        }
    };
    const buttonVariant = () => {
        if (colorScheme === "dark") {
            return "light";
        } else return "filled";
    };
    const handleClick = (status: string) => {
        if (status === "include") {
            if (props.tag.state === "include") {
                props.update(props.tag, "default");
            } else {
                props.update(props.tag, "include");
            }
        } else {
            if (props.tag.state === "exclude") {
                props.update(props.tag, "default");
            } else {
                props.update(props.tag, "exclude");
            }
        }
    };
    const getHover = () => {
        return colorScheme == "light" ? styles.light_hover : styles.dark_hover
    }
    const getClassname = () => {
        return tagBackground() + " " + styles.container_padding + ' ' + getHover() + ' ' + getHighlight()
    }
    const getHighlight = () => {
        if (props.tag.state != "default") {
            if (colorScheme == "light") {
                return styles.light_background
            } else if (colorScheme == "dark") {
                return styles.dark_background
            }
        }
    }

    return (
        <>
            <Group justify="space-between" className={getClassname()}>
                <Button
                    variant={buttonVariant()}
                    color="green"
                    onClick={() => handleClick("include")}
                    miw={"0.5em"}
                    bd={"none"}
                >
                    <PlusIcon width={"1em"} />
                </Button>
                <Text>{props.tag.value}</Text>
                <Button
                    variant={buttonVariant()}
                    color="red"
                    onClick={() => handleClick("exclude")}
                    miw={"0.5em"}
                    bd={"none"}
                >
                    <MinusIcon width={"1em"} />
                </Button>
            </Group>
        </>
    );
};

export default HomeTagBox;
