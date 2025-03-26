import { Stack, Title, Box, Group, Badge, Text, useComputedColorScheme, useMantineTheme, SimpleGrid, Center } from "@mantine/core";
import { ISubgenre, ITag } from "../../Types/api";
import styles from './DetailsIntro.module.css'
import { Carousel } from "@mantine/carousel";

function DetailsIntro({ name, desc, tags, subgenres, examples }: { name: string, desc: string, tags: ITag[], subgenres: ISubgenre[] | undefined , examples: string[] }) {
    const theme = useMantineTheme();
    const scheme = useComputedColorScheme();
  return (
      <Stack>
          <SimpleGrid cols={{ base: 1, xl: 2 }} verticalSpacing="md" spacing="md">
              <Stack justify="center" align="center">
                  <Title order={1} id={name} c={scheme === 'dark' ? 'white' : 'black'}>{name}</Title>
                  <Text w="80%">
                          {desc}
                      </Text>
              </Stack>
              <Center>
                  <Box className={styles.wrapper}>
                      <Carousel withIndicators controlSize={40} slideSize="100%" loop>
                          {examples && examples.map((i) => (<Carousel.Slide key={i}><iframe
                              className={styles.ytframe}
                              loading="lazy"
                              src={`https://www.youtube.com/embed/${i}`}
                              allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
                              referrerPolicy="strict-origin-when-cross-origin"
                          ></iframe></Carousel.Slide>))}
                      </Carousel>
                  </Box>
              </Center>
              <Stack className={styles.container_radius} align="center">
                  <Title order={2} id="Tags">Tags</Title>
                  <Group>
                      {tags.map((element) => (
                          <Badge color="indigo" variant="light" key={element.tagId}>{element.name}</Badge>
                      ))}
                  </Group>
              </Stack>
              {subgenres && <Stack className={styles.container_radius} align="center">
                  <Title order={2} id="Subgenres">Subgenres</Title>
                  <Group>
                      {subgenres && subgenres.map((element) => (
                          <Badge key={element.subgenreId} color="indigo" variant="light">{element.name}</Badge>
                      ))}
                  </Group>
              </Stack>}
          </SimpleGrid>
      </Stack>
  );
}

export default DetailsIntro;