import { Button, Group, Text, useMantineColorScheme } from "@mantine/core";
import { MinusIcon, PlusIcon } from "@radix-ui/react-icons";
import { ITagData, tagStateType } from "../../Types/hometag";
import './HomeTagBox.css'
interface Props {
    tag: ITagData;
    update: (tag: ITagData, state: tagStateType) => void;
}

const HomeTagBox = (props: Props) => {
    const { colorScheme, setColorScheme } = useMantineColorScheme();
    const buttonVariant = () => {
        if (colorScheme === "dark") {
            return "light";
        } else return "filled";
    };
    const handleClick = (status: tagStateType) => {
        if (status === props.tag.state) {
            props.update(props.tag, "default")
        } else {
            props.update(props.tag, status)
        }
    };
    
    const getHighlight = () => {
        if (props.tag.state != "default") {
            if (colorScheme == "light") {
                return 'light_background'
            } else if (colorScheme == "dark") {
                return 'dark_background'
            }
        }
    }
    return (
        <>
            <Group justify="space-between" className={`${props.tag.state}_${colorScheme} container_padding ${colorScheme}_box ${getHighlight()}`}>
                <Button
                    variant={buttonVariant()}
                    color="green"
                    onClick={() => handleClick("include")}
                    miw={"0.5em"}
                    bd={"none"}
                >
                    <PlusIcon width={"1em"} />
                </Button>
                <Text>{props.tag.value} {props.tag.id}</Text>
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
